using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public class UserShoppingCartDto
    {
        public IEnumerable<ProductDtoShoppingCart> Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
