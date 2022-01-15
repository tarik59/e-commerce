using EC_Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EC_Domain.Identity
{
    public class AppUser : IdentityUser
    {
        //public string Username { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public ICollection<Order> orders { get; set; }
    }
}
