using RemAcademy.Business.Operations.Order.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Business.Operations.Order
{
    public interface IOrderService
    {
        Task CreateOrder(OrderDto orderDto);        
        Task<OrderDto> GetOrder(int orderId);
    }
}
