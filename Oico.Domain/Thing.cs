using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oico.Domain
{
    public class Thing
    {
        public Guid Id { get; set; }
        public string NameOfProduct { get; set; }
        public int CountOfProduct { get; set; }
    }
}
