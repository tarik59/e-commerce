using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public class AppUserForOrderDto
    {
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
    }
}
