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
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(Product product)
        {
            await dbContext.AddAsync(product);
        }

        public async Task Delete(Guid Id)
        {
            Product product = await dbContext.Products.FindAsync(Id);

            if(product is not null)
            {
                dbContext.Products.Remove(product);
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
           return await dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetById(Guid Id)
        {
            return await dbContext.Products.FindAsync(Id);
        }

        public IQueryable<Product> GetByName(string name)
        {
            return dbContext.Products.Where(w => w.Name.Contains(name)).Select(p => p);
        }

        public async Task SaveComplete()
        {
            await dbContext.SaveChangesAsync();
        }

        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
