using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public class ProductDtoShoppingCart : ProductDto
    {
        public int QuantityInShoppingCart { get; set; }
        public double productTotalPrice { get; set; }
    }
}
