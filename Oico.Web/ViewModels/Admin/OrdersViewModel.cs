using Oico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oico.Web.ViewModels.Admin
{
    public class OrdersViewModel
    {
        public IEnumerable<Order> NewOrders { get; set; }
        public IEnumerable<Order> OrdersOnWeek { get; set; }
        public IEnumerable<Order> OrdersOnYear { get; set; }
        public IEnumerable<Order> OrdersOnMonth { get; set; }
        public IEnumerable<Order> OrdersOnToday { get; set; }
    }
}
