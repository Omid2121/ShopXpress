using AutoMapper;
using ShopXpress.Bll.DTOs;
using ShopXpress.DAL.IRepository;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.BLL.Services
{
    public class CartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Product> GetProduct(Guid productId)
        {
            return await _unitOfWork.Products.Get(p => p.Id == productId);
        }

        public async Task<Cart> GetCartWithUserId(Guid cartId, string userId)
        {
            return await _unitOfWork.Carts.Get(c => c.Id == cartId && c.UserId == userId);
        }

        public async Task UpdateExistingCartItem(Cart cart, CartItem cartItem, int quantity)
        {
            Product product = await GetProduct(cartItem.ProductId);
            if (product == null) return;

            cartItem.Quantity += quantity;
            cartItem.Total = cartItem.Quantity * product.UnitPrice;

            _unitOfWork.CartItems.Update(cartItem);
            await _unitOfWork.Save();

            await UpdateCartTotal(cart);
        }

        public async Task AddNewCartItem(Cart cart, CreateCartItemDTO cartItemDTO)
        {
            Product product = await GetProduct(cartItemDTO.ProductId);
            if (product == null) return;

            var newCartItem = _mapper.Map<CartItem>(cartItemDTO);
            newCartItem.CartId = cart.Id;
            newCartItem.Total = newCartItem.Quantity * product.UnitPrice;

            // Update cart's total
            cart.Total += newCartItem.Total;

            await _unitOfWork.CartItems.Insert(newCartItem);
            _unitOfWork.Carts.Update(cart);
            await _unitOfWork.Save();
        }

        public async Task UpdateCartItem(Cart cart, CartItem cartItem, UpdateCartItemDTO cartItemDTO)
        {
            _mapper.Map(cartItemDTO, cartItem);
            Product product = await GetProduct(cartItem.ProductId);
            if (product == null) return;

            cartItem.Total = cartItem.Quantity * product.UnitPrice;
            _unitOfWork.CartItems.Update(cartItem);
            await _unitOfWork.Save();

            await UpdateCartTotal(cart);
        }

        private async Task UpdateCartTotal(Cart cart)
        {
            var cartItems = await _unitOfWork.CartItems.GetAll(ci => ci.CartId == cart.Id);
            cart.Total = cartItems.Sum(ci => ci.Total);
            _unitOfWork.Carts.Update(cart);
            await _unitOfWork.Save();
        }
    }
}
