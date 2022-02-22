using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EC_Domain.Entity
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        
        [Required]
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Model { get; set; }
        public int brandId { get; set; }
        public Brand Brand { get; set; }
        public int genderId { get; set; }
        public Gender Gender { get; set; }
        public int typeOfProductId { get; set; }
        public TypeOfProduct TypeOfProduct { get; set; }
        public ICollection<ShoppingCart> shoppingCarts { get; set; }
        public ICollection<Order> orders { get; set; }
        public string ImageUrl { get; set; }
    }
}
