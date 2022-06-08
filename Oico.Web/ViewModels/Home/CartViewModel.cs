using Oico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oico.Web.ViewModels.Home
{
    public class CartViewModel : AllProductsViewModel
    {
        public string Username { get; set; }
        public string Phone { get; set; }

        public List<Guid> GuidsOfProducts { get; set; }
    }
}
