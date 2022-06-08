using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

        public void CompleteOrder(Order order)
        {
            var eOrder = dbContext.Attach(order);
            eOrder.State = EntityState.Modified;
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
            Order order = await dbContext.Orders.Include(p => p.Things).Where(w => w.Id.Equals(Id)).FirstOrDefaultAsync();
            return order;
        }

        public async Task SaveComplete()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
