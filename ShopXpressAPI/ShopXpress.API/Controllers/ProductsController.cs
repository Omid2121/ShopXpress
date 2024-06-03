using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopXpress.Bll.DTOs;
using ShopXpress.BLL.Services;
using ShopXpress.DAL.IRepository;
using ShopXpress.DAL.Models;
using ShopXpress.Models;
using ShopXpress.Models.Data;

namespace ShopXpress.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ProductsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuthManager _authManager;

    public ProductsController(IUnitOfWork unitOfWork, IMapper mapper, IAuthManager authManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authManager = authManager;
    }

    [HttpGet]
    [Authorize(Roles = "Administrator, Consumer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetProducts([FromQuery]RequestParams requestParams)
    {
        var products = await _unitOfWork.Products.GetPagedList(requestParams, includes: new List<string> { "Category" });
        var results = _mapper.Map<IEnumerable<ProductDTO>>(products);

        return Ok(results);
    }

    [HttpGet("{productId}", Name = "GetProduct")]
    [Authorize(Roles = "Administrator, Consumer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProduct(Guid productId)
    {
        var product = await _unitOfWork.Products.Get(p => p.Id == productId, new List<string> { "Category" });
        if (product == null) return NotFound();

        var result = _mapper.Map<ProductDTO>(product);

        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO productDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        Product product = _mapper.Map<Product>(productDTO);
        await _unitOfWork.Products.Insert(product);
        await _unitOfWork.Save();

        return CreatedAtRoute("GetProduct", new { productId = product.Id }, product);
    }

    [HttpPut("{productId}")]
    [Authorize(Roles = "Administrator")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody] UpdateProductDTO productDTO)
    {
        if (!ModelState.IsValid || productId == Guid.Empty) return BadRequest(ModelState);

        Product product = await _unitOfWork.Products.Get(p => p.Id == productId);
        if (product == null) return NotFound();

        var result = _mapper.Map(productDTO, product);

        _unitOfWork.Products.Update(product);
        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpDelete("{productId}")]
    [Authorize(Roles = "Administrator")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        if (productId == Guid.Empty) return BadRequest();

        Product product = await _unitOfWork.Products.Get(p => p.Id == productId);
        if (product == null) return NotFound();

        await _unitOfWork.Products.Delete(product.Id);
        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpGet("search")]
    [Authorize(Roles = "Administrator, Consumer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> SearchProducts(string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString)) return BadRequest();

        var products = await _unitOfWork.Products.Search(searchString);

        var results = _mapper.Map<IEnumerable<ProductDTO>>(products);

        return Ok(results);
    }
}
