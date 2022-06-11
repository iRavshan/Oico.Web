using Microsoft.EntityFrameworkCore;
using Oico.Data.Repositories;
using Oico.Domain;
using Oico.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oico.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            this.orderRepo = orderRepo;
        }

        public void CompleteOrder(Order order)
        {
            orderRepo.CompleteOrder(order);
            orderRepo.SaveComplete();
        }

        public async Task Create(Order order)
        {
            await orderRepo.Create(order);
            await orderRepo.SaveComplete();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return (await orderRepo.GetAll());
        }

        public async Task<Order> GetById(Guid Id)
        {
            return await orderRepo.GetById(Id);
        }

        public async Task<IEnumerable<Order>> GetCompletedOrders()
        {
            return (await orderRepo.GetAll()).Where(w => w.IsComplete == true).ToList();
        }

        public async Task<IEnumerable<Order>> GetNewOrders()
        {
            return (await orderRepo.GetAll()).Where(w => w.IsComplete == false)
                                             .OrderByDescending(p => p.AcceptedTime);

        }

        public async Task<IEnumerable<Order>> OrdersOnLastMonth()
        {
            IEnumerable<Order> orders = (await orderRepo.GetAll())
                                    .Where(w => w.IsComplete == true)
                                    .OrderByDescending(p => p.ConfirmedTime);

            IEnumerable<Order> ordersOnLastMonth = orders.Where(w => 
                                    w.ConfirmedTime.Month.Equals(DateTime.Now.Month) && 
                                    w.ConfirmedTime.Year.Equals(DateTime.Now.Year));

            return ordersOnLastMonth;
        }

        public async Task<IEnumerable<Order>> OrdersOnLastWeek()
        {
            IEnumerable<Order> orders = (await orderRepo.GetAll())
                                     .Where(w => w.IsComplete == true)
                                     .OrderByDescending(p => p.ConfirmedTime);

            IEnumerable<Order> ordersOnLastMonth = orders.Where(w =>
                                    w.ConfirmedTime.Month.Equals(DateTime.Now.Month) &&
                                    w.ConfirmedTime.Year.Equals(DateTime.Now.Year));

            IEnumerable<Order> ordersOnLastWeek = ordersOnLastMonth.TakeLast(7).ToList();

            return ordersOnLastWeek;
        }

        public async Task<IEnumerable<Order>> OrdersOnLastYear()
        {
            IEnumerable<Order> orders = (await orderRepo.GetAll())
                                    .Where(w => w.IsComplete == true)
                                    .OrderByDescending(p => p.ConfirmedTime);

            IEnumerable<Order> ordersOnLastYear = orders.Where(w =>
                                    w.ConfirmedTime.Year.Equals(DateTime.Now.Year));

            return ordersOnLastYear;
        }

        public async Task<IEnumerable<Order>> OrdersOnToday()
        {
            IEnumerable<Order> orders = (await orderRepo.GetAll())
                                    .Where(w => w.IsComplete == true)
                                    .OrderByDescending(p => p.ConfirmedTime);

            IEnumerable<Order> ordersOnToday = orders.Where(w =>
                                    w.ConfirmedTime.Date.Equals(DateTime.Now.Date) &&
                                    w.ConfirmedTime.Month.Equals(DateTime.Now.Month) &&
                                    w.ConfirmedTime.Year.Equals(DateTime.Now.Year));

            return ordersOnToday;
        }
    }
}
