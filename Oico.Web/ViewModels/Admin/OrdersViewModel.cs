using Oico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oico.Web.ViewModels.Admin
{
    public class OrdersViewModel
    {
        public IEnumerable<Order> CompletedOrders { get; set; }
        public IEnumerable<Order> NewOrders { get; set; }
    }
}
