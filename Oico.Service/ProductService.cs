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
    }
}
