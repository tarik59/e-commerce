using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC_Domain.Entity
{
    public class ProductInOrder
    {
        public int productId { get; set; }
        public Product Product { get; set; }
        public int orderId { get; set; }
        public Order Order { get; set; }

    }
}
