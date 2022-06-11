using Oico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oico.Service.Services
{
    public interface IOrderService
    {
        Task Create(Order order);
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(Guid Id);
        Task<IEnumerable<Order>> GetCompletedOrders();
        Task<IEnumerable<Order>> GetNewOrders();
        void CompleteOrder(Order order);
        Task<IEnumerable<Order>> OrdersOnLastWeek();
        Task<IEnumerable<Order>> OrdersOnLastYear();
        Task<IEnumerable<Order>> OrdersOnLastMonth();
        Task<IEnumerable<Order>> OrdersOnToday();
    }
}
