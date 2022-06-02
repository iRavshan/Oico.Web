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
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepo;

        public ProductService(IProductRepository productRepo)
        {
            this.productRepo = productRepo;
        }

        public async Task Create(Product product)
        {
            await productRepo.Create(product);
            await productRepo.SaveComplete();
        }

        public async Task Delete(Guid Id)
        {
            await productRepo.Delete(Id);
            await productRepo.SaveComplete();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await productRepo.GetAll();
        }

        public async Task<Product> GetById(Guid Id)
        {
            return await productRepo.GetById(Id);
        }

        public async Task<IEnumerable<Product>> GetByShortName(string shortname)
        {
            IEnumerable<Product> products = await productRepo.GetAll();
            IEnumerable<Product> result = products.Where(w => w.Name.ToLower().Contains(shortname.ToLower())).Select(p => p).ToList();            
            return result;
        }

        public async Task<IEnumerable<Product>> LastProducts(int count)
        {
            var items = Enumerable.Reverse(await productRepo.GetAll());

            return items.Take(count).Select(w => w);
        }

        public void Update(Product product)
        {
            productRepo.Update(product);
            productRepo.SaveComplete();
        }
    }
}
