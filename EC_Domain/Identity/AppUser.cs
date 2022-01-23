using EC_Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EC_Domain.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public ICollection<Order> orders { get; set; }
        public ICollection<AppRole> Roles { get; set; }
    }
}
