using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oico.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int WholesalePrice { get; set; }
        public int NumberOfBox { get; set; }
        public int NumberOfBoxes { get; set; }
        public string ImageUrl { get; set; }
        public int Massa { get; set; }
    }
}
