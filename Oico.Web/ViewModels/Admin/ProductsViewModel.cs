using Oico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oico.Web.ViewModels.Admin
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> AllProducts { get; set; }
    }
}
