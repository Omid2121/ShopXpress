using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShopXpress.Bll.DTOs;
using ShopXpress.BLL.Services;
using ShopXpress.DAL.IRepository;
using ShopXpress.DAL.Models;
using ShopXpress.Models;
using ShopXpress.Models.Data;
using System.Security.Claims;

namespace ShopXpress.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class AccountsController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly IAuthManager _authManager;
    private readonly IUnitOfWork _unitOfWork;

    public AccountsController(UserManager<User> userManager, IMapper mapper, IAuthManager authManager, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _mapper = mapper;
        _authManager = authManager;
        _unitOfWork = unitOfWork;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] CreateUserDTO userDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = _mapper.Map<User>(userDTO);
        user.UserName = userDTO.Email;
        user.CartId = Guid.NewGuid();
        CreateCartDTO cartDTO = new() { Id = user.CartId, UserId = user.Id };
        user.Cart = _mapper.Map<Cart>(cartDTO);

        var result = await _userManager.CreateAsync(user, userDTO.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }
        await _userManager.AddToRoleAsync(user, Role.Consumer);

        return Accepted();
    }

    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (!await _authManager.ValidateUser(loginDTO)) return Unauthorized();

        return Accepted(new AuthResponse
        {
            Token = await _authManager.CreateAccessToken(),
            RefreshToken = await _authManager.CreateRefreshToken()
        });
    }

    [HttpGet("user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUser()
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (currentUserId == null) return BadRequest();

        var user = await _authManager.GetUser(currentUserId);
        user.Cart = await _unitOfWork.Carts.Get(c => c.UserId == currentUserId, new List<string> { "CartItems", "CartItems.Product" });
        user.Orders = await _unitOfWork.Orders.GetAll(o => o.UserId == currentUserId, includes: new List<string> { "OrderItems", "OrderItems.Product" });

        if (user == null) return NotFound();

        var result = _mapper.Map<UserDTO>(user);

        return Ok(result);
    }

    [HttpPost("refresh-token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> RefreshToken([FromBody] AuthRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _authManager.VerifyRefreshToken(request);

        if (result == null) return Unauthorized();

        return Ok(result);
    }

    //[HttpPost("revoke-token")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<IActionResult> RevokeToken()
    //{
    //    return Ok();
    //}

    [HttpPut("update{accountId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAccount(string accountId, UpdateUserDTO userDTO)
    {
        if (!ModelState.IsValid || string.IsNullOrEmpty(accountId)) return BadRequest(ModelState);

        var user = await _userManager.FindByIdAsync(accountId);
        if (user == null) return BadRequest("Something went wrong");

        _mapper.Map(userDTO, user);
        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }

        return NoContent();
    }

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> DeleteAccount([FromBody] DeleteUserDTO userDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = await _userManager.FindByEmailAsync(userDTO.Email);
        if (user == null) return NotFound("Does not exist");

        if (!await _authManager.ValidateUser(userDTO)) return Unauthorized();

        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }

        return NoContent();
    }
}
