using Oico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oico.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<Product> AllProducts { get; set; }
        public IEnumerable<Product> LastProducts { get; set; }
        public string SearchText { get; set; }
    }
}
