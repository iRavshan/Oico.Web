using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oico.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Client { get; set; }
    }
}
