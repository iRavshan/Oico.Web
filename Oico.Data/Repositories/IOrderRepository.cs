using Microsoft.EntityFrameworkCore.Query;
using Oico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oico.Data.Repositories
{
    public interface IOrderRepository
    {
        Task Create(Order order);
        Task SaveComplete();
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(Guid Id);
        void CompleteOrder(Order order);
    }
}
