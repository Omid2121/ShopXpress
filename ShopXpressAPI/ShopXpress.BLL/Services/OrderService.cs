using ShopXpress.Bll.DTOs;
using ShopXpress.DAL.IRepository;
using ShopXpress.DAL.Repository;
using ShopXpress.Models.Data;
using ShopXpress.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.BLL.Services
{
    public class OrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> PlaceOrderAsync(Order order)
        {
            // Checks if products are in stock
            await IsProductsInStock(order.OrderItems);
            var transaction = _unitOfWork.BeginTransaction();
            try
            {
                // Create order items
                var orderItems = order.OrderItems.Select(orderItem => new OrderItem
                {
                    //Id = Guid.NewGuid(),
                    Quantity = orderItem.Quantity,
                    Total = orderItem.Total,
                    ProductId = orderItem.ProductId
                }).ToList();
                // Update stock quantity
                foreach (var orderItem in orderItems)
                {
                    await UpdateStockQuantity(orderItem.ProductId, orderItem.Quantity);
                }
                Order newOrder = new()
                {
                    OrderNumber = Guid.NewGuid().ToString(),
                    CreatedAt = DateTimeOffset.UtcNow,
                    ShippingDate = DateTimeOffset.UtcNow.AddDays(3),
                    Status = Status.Processing,
                    Total = orderItems.Sum(item => item.Total),
                    Address = order.Address,
                    UserId = order.UserId,
                    OrderItems = orderItems
                };
                await _unitOfWork.Orders.Insert(newOrder);
                await _unitOfWork.Save();
                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
        private async Task<bool> IsProductsInStock(IEnumerable<OrderItem> orderItems)
        {
            foreach (var orderItem in orderItems)
            {
                var product = await _unitOfWork.Products.Get(p => p.Id == orderItem.ProductId);
                if (product == null || product.StockQuantity < orderItem.Quantity) return false;
            }
            return true;
        }
        public async Task UpdateStockQuantity(Guid productId, int quantityChange)
        {
            var product = await _unitOfWork.Products.Get(p => p.Id == productId);
            if (product != null)
            {
                product.StockQuantity -= quantityChange;

                _unitOfWork.Products.Update(product);
                await _unitOfWork.Save();
            }
            else
            {
                throw new ArgumentNullException(nameof(product), "Product not found");
            }
        }
    }
}
