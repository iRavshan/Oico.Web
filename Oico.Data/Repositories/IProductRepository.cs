using Oico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oico.Data.Repositories
{
    public interface IProductRepository
    {
        Task Create(Product product);
        void Update(Product product);
        Task Delete(Guid Id);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid Id);
        IQueryable<Product> GetByName(string name);
        Task SaveComplete();
    }
}
