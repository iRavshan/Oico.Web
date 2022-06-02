using Oico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oico.Web.ViewModels.Home
{
    public class AllProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
