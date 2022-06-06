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

        public async Task Create(Order order)
        {
            await orderRepo.Create(order);
            await orderRepo.SaveComplete();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await orderRepo.GetAll();
        }

        public async Task<Order> GetById(Guid Id)
        {
            return await orderRepo.GetById(Id);
        }
    }
}
