using Microsoft.EntityFrameworkCore;
using Oico.Data.Repositories;
using Oico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oico.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext dbContext;

        public OrderRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(Order order)
        {
            await dbContext.Orders.AddAsync(order);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await dbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetById(Guid Id)
        {
            return await dbContext.Orders.FindAsync(Id);
        }

        public async Task SaveComplete()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
