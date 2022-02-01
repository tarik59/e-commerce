using EC_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public string Model { get; set; }
        public int brandId { get; set; }
        public Brand Brand { get; set; }
        public Gender Gender { get; set; }
        public int typeOfProductId { get; set; }
        public TypeOfProduct TypeOfProduct { get; set; }
    }
}
