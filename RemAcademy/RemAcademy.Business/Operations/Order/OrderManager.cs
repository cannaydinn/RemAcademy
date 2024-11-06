using Microsoft.EntityFrameworkCore;
using RemAcademy.Business.Operations.Order.Dtos;
using RemAcademy.Business.Operations.Product.Dtos;
using RemAcademy.Data.Entities;
using RemAcademy.Data.Repositories;
using RemAcademy.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Business.Operations.Order
{
    public class OrderManager : IOrderService
    {
        private readonly IRepository<OrderEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderManager(IRepository<OrderEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public async Task CreateOrder(OrderDto orderDto)
        {
            var order = new OrderEntity
            {
                TeacherId = orderDto.TeacherId,
                OrderDate = DateTime.Now,
                TotalAmount = orderDto.TotalAmount
            };

            foreach (var product in orderDto.Products)
            {
                order.OrderProducts.Add(new OrderProductEntity
                {
                    ProductId = product.ProductId,
                    OrderId = product.OrderId
                });
            }

            _repository.Add(order);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Sipariş sırasında bir hata oluştu!!!!");
            }
            
        }

        public async Task<OrderDto> GetOrder(int id)
        {
            var order = await _repository.GetAll()
                .Select(x => new OrderDto
                {
                    Id = x.Id,
                    TotalAmount = x.TotalAmount,
                    TeacherId = x.TeacherId,
                    OrderDate = DateTime.Now,

                }).FirstOrDefaultAsync();

            return order;
        }
    }
}
