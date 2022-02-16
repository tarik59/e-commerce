using EC_Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EC_Domain.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public ICollection<Order> orders { get; set; }
        public ICollection<AppRole> Roles { get; set; }
        public ShoppingCart ShoppingCart { get; set; } = new ShoppingCart();
    }
}
