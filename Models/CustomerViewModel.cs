using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DexaApps.Models
{
    public class CustomerViewModel
    {
        public Customers Customers { get; set; }
        public ICollection<Customers> ListCustomer { get; set; }
        public Outlets Outelets { get; set; }
        public ICollection<Outlets> ListOutlets { get; set; }
    }
}
