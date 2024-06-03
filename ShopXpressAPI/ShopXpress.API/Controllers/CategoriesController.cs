using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopXpress.Bll.DTOs;
using ShopXpress.BLL.Services;
using ShopXpress.DAL.IRepository;
using ShopXpress.DAL.Repository;
using ShopXpress.Models.Data;
using System.Security.Claims;

namespace ShopXpress.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
public class CategoriesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuthManager _authManager;

    public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper, IAuthManager authManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authManager = authManager;
    }

    [HttpGet]
    [Authorize(Roles = "Administrator, Consumer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategories()
    {
        // Get all categories
        var categories = await _unitOfWork.Categories.GetAll();
        var results = _mapper.Map<IEnumerable<CategoryDTO>>(categories);

        return Ok(results);
    }

    [HttpGet("{categoryId}")]
    [Authorize(Roles = "Administrator, Consumer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCategory(Guid categoryId)
    {
        // Get category by id and include its products
        Category category = await _unitOfWork.Categories.Get(c => c.Id == categoryId, new List<string> { "Products" });
        if (category == null) return NotFound();

        var result = _mapper.Map<CategoryDTO>(category);

        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO categoryDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        Category category = _mapper.Map<Category>(categoryDTO);
        await _unitOfWork.Categories.Insert(category);
        await _unitOfWork.Save();

        return Created("GetCategory", category);
    }

    [HttpPut("{categoryId}")]
    [Authorize(Roles = "Administrator")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCategory(Guid categoryId, [FromBody] UpdateCategoryDTO categoryDTO)
    {
        if (!ModelState.IsValid || categoryId == Guid.Empty) return BadRequest(ModelState);

        Category category = await _unitOfWork.Categories.Get(c => c.Id == categoryId);
        if (category == null) return NotFound();

        _mapper.Map(categoryDTO, category);

        _unitOfWork.Categories.Update(category);
        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpDelete("{categoryId}")]
    [Authorize(Roles = "Administrator")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCategory(Guid categoryId)
    {
        if (categoryId == Guid.Empty) return BadRequest();

        Category category = await _unitOfWork.Categories.Get(c => c.Id == categoryId);
        if (category == null) return NotFound();

        await _unitOfWork.Categories.Delete(category.Id);
        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpGet("{categoryId}/products")]
    [Authorize(Roles = "Administrator, Consumer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductsByCategory(Guid categoryId)
    {
        if (categoryId == Guid.Empty) return BadRequest();
        
        // get products by category id
        var products = await _unitOfWork.Products.GetAll(p => p.CategoryId == categoryId);
        var results = _mapper.Map<IEnumerable<ProductDTO>>(products);

        return Ok(results);
    }
}
