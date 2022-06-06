using Oico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oico.Service.Services
{
    public interface IProductService
    {
        Task Create(Product product);
        Task<IEnumerable<Product>> GetAll();
        Task<IEnumerable<Product>> LastProducts(int count);
        Task<Product> GetById(Guid Id);
        Task Delete(Guid Id);
        void Update(Product product);
        Task<IEnumerable<Product>> GetByShortName(string shortname);
        Task<Product> GetByName(string name);
    }
}
