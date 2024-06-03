using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopXpress.Bll.DTOs;
using ShopXpress.BLL.Services;
using ShopXpress.DAL.IRepository;
using ShopXpress.DAL.Models;
using ShopXpress.Models;
using ShopXpress.Models.Data;
using ShopXpress.Models.Enums;
using System.Security.Claims;
using X.PagedList;

namespace ShopXpress.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly OrderService _orderService;
    private readonly IMapper _mapper;
    private readonly IAuthManager _authManager;
    private Order _order;
    private IList<Order> _orders;
    private OrderItem _orderItem;
    private IList<OrderItem> _orderItems;


    public OrdersController(IUnitOfWork unitOfWork, IMapper mapper, IAuthManager authManager, OrderService orderService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authManager = authManager;
        _orderService = orderService;
    }

    [HttpGet]
    [Authorize(Roles = "Administrator, Consumer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetOrders()
    {
        var isAdmin = User.IsInRole(Role.Administrator);
        if (isAdmin)
        {
            _orders = await _unitOfWork.Orders.GetAll();
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _orders = await _unitOfWork.Orders.GetAll(o => o.UserId == currentUserId, includes: new List<string> { "OrderItems", "OrderItems.Product" });
        }
        var results = _mapper.Map<IEnumerable<OrderDTO>>(_orders);
        return Ok(results);
    }

    [HttpGet("{orderId}", Name = "GetOrder")]
    [Authorize(Roles = "Administrator, Consumer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetOrder(Guid orderId)
    {
        if (orderId == Guid.Empty) return BadRequest();

        var isAdmin = User.IsInRole(Role.Administrator);
        if (isAdmin)
        {
            _order = await _unitOfWork.Orders.Get(o => o.Id == orderId, new List<string> { "OrderItems", "OrderItems.Product" });
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _order = await _unitOfWork.Orders.Get(
                o => o.Id == orderId && o.UserId == currentUserId, new List<string> { "OrderItems", "OrderItems.Product" });
        }

        if (_order == null) return NotFound();

        var result = _mapper.Map<OrderDTO>(_order);

        return Ok(result);
    }

    [HttpGet("{orderId}/orderItems")]
    [Authorize(Roles = "Administrator, Consumer")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetOrderItems(Guid orderId)
    {
        if (orderId == Guid.Empty) return BadRequest();

        var isAdmin = User.IsInRole(Role.Administrator);
        if (isAdmin)
        {
            _orderItems = await _unitOfWork.OrderItems.GetAll(orderItem => orderItem.OrderId == orderId, includes: new List<string> { "Product" });
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _orderItems = await _unitOfWork.OrderItems
                .GetAll(orderItem => orderItem.OrderId == orderId && orderItem.Order.UserId == currentUserId,
                includes: new List<string> { "Product" });
        }
        if (_orderItems == null) return NotFound();

        var results = _mapper.Map<IEnumerable<OrderItemDTO>>(_orderItems);

        return Ok(results);
    }

    [HttpPost]
    [Authorize(Roles = "Consumer")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> PlaceOrder([FromBody] CreateOrderDTO orderDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var order = _mapper.Map<Order>(orderDTO);
        if (order.Address == null)
        {
            var user = await _authManager.GetUser(order.UserId);
            order.Address = user.Address;
        }
        var result = await _orderService.PlaceOrderAsync(order);
        if (!result) return BadRequest("Order could not be placed.");

        return Accepted();
    }

    [HttpPut("{orderId}/status")]
    [Authorize(Roles = "Administrator")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ChangeOrderStatus(Guid orderId, [FromBody] ChangeOrderStatusDTO changeOrderStatusDTO)
    {
        if (!ModelState.IsValid || orderId == Guid.Empty) return BadRequest(ModelState);

        var order = await _unitOfWork.Orders.Get(o => o.Id == orderId);
        if (order == null) return NotFound();

        order.Status = changeOrderStatusDTO.Status;
        _unitOfWork.Orders.Update(order);
        await _unitOfWork.Save();

        return NoContent();
    }
}
