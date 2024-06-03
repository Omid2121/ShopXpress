using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopXpress.Bll.DTOs;
using ShopXpress.BLL.Services;
using ShopXpress.DAL.IRepository;
using ShopXpress.Models.Data;
using System.Security.Claims;

namespace ShopXpress.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CartService _cartService;
    private readonly IMapper _mapper;
    private readonly IAuthManager _authManager;
    private Cart _cart;
    private CartItem _cartItem;
    private IList<CartItem> _cartItems;

    public CartsController(IUnitOfWork unitOfWork,CartService cartService, IMapper mapper, IAuthManager authManager)
    {
        _unitOfWork = unitOfWork;
        _cartService = cartService;
        _mapper = mapper;
        _authManager = authManager;
    }

    [HttpGet("{cartId}", Name = "GetCart")]
    [Authorize(Roles = "Consumer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCart(Guid cartId)
    {
        if (cartId == Guid.Empty) return BadRequest();

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        _cart = await _unitOfWork.Carts.Get(
                c => c.Id == cartId && c.UserId == currentUserId, new List<string> { "CartItems", "CartItems.Product" });

        if (_cart == null) return NotFound();

        var result = _mapper.Map<CartDTO>(_cart);

        return Ok(result);
    }

    [HttpGet("/{cartId}/cartItems")]
    [Authorize(Roles = "Consumer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetCartItems(Guid cartId)
    {
        if (cartId == Guid.Empty) return BadRequest();

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        _cartItems = await _unitOfWork.CartItems.GetAll(
                       cartItem => cartItem.CartId == cartId && cartItem.Cart.UserId == currentUserId, includes: new List<string> { "Product" });

        var results = _mapper.Map<IEnumerable<CartItemDTO>>(_cartItems);

        return Ok(results);
    }

    [HttpGet("/{cartId}/cartItems/{cartItemId}", Name = "GetCartItem")]
    [Authorize(Roles = "Consumer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCartItem(Guid cartId, Guid cartItemId)
    {
        if (cartId == Guid.Empty || cartItemId == Guid.Empty) return BadRequest();

        //TODO: test this
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        _cartItem = await _unitOfWork.CartItems.Get(
                                  cartItem => cartItem.CartId == cartId && cartItem.Cart.UserId == currentUserId && cartItem.Id == cartItemId);

        if (_cartItem == null) return NotFound();
        
        var result = _mapper.Map<CartItemDTO>(_cartItem);

        return Ok(result);
    }

    [HttpPost("{cartId}/cartItems")]
    [Authorize(Roles = "Consumer")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> AddCartItemToCart(Guid cartId, [FromBody] CreateCartItemDTO cartItemDTO)
    {
        if (!ModelState.IsValid || cartId == Guid.Empty) return BadRequest(ModelState);

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var cart = await _cartService.GetCartWithUserId(cartId, currentUserId);
        if (cart == null) return NotFound();

        var cartItem = await _unitOfWork.CartItems.Get(cartItem => cartItem.CartId == cartId && cartItem.ProductId == cartItemDTO.ProductId);
        if (cartItem != null)
        {
            await _cartService.UpdateExistingCartItem(cart, cartItem, cartItemDTO.Quantity);
        }
        else
        {
            await _cartService.AddNewCartItem(cart, cartItemDTO);
        }

        return NoContent();
    }

    [HttpPut("{cartId}/cartItems/{cartItemId}")]
    [Authorize(Roles = "Consumer")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCartItemInCart(Guid cartId, Guid cartItemId, [FromBody] UpdateCartItemDTO cartItemDTO)
    {
        if (!ModelState.IsValid || cartId == Guid.Empty || cartItemId == Guid.Empty) return BadRequest(ModelState);

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var cart = await _cartService.GetCartWithUserId(cartId, currentUserId);
        if (cart == null) return NotFound();

        var cartItem = await _unitOfWork.CartItems.Get(cartItem => cartItem.CartId == cartId && cartItem.Id == cartItemId);
        if (cartItem == null) return NotFound();

        await _cartService.UpdateCartItem(cart, cartItem, cartItemDTO);

        return NoContent();
    }

    [HttpDelete("{cartId}/cartItems/{cartItemId}")]
    [Authorize(Roles = "Consumer")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteCartItemInCart(Guid cartId, Guid cartItemId)
    {
        if (cartId == Guid.Empty || cartItemId == Guid.Empty) return BadRequest();

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        _cartItem = await _unitOfWork.CartItems.Get(
                       cartItem => cartItem.CartId == cartId && cartItem.Cart.UserId == currentUserId && cartItem.Id == cartItemId);

        if (_cartItem == null) return NotFound();

        await _unitOfWork.CartItems.Delete(cartItemId);
        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpDelete("{cartId}/cartItems")]
    [Authorize(Roles = "Consumer")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ClearCart(Guid cartId)
    {
        if (cartId == Guid.Empty) return BadRequest();

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        _cartItems = await _unitOfWork.CartItems.GetAll(
                                  cartItem => cartItem.CartId == cartId && cartItem.Cart.UserId == currentUserId);

        if (_cartItems == null) return NotFound();

        _unitOfWork.CartItems.DeleteRange(_cartItems);
        await _unitOfWork.Save();

        return NoContent();
    }
}
