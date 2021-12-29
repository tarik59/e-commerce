using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EC_Domain.Identity
{
    public class AppUser:IdentityUser
    {
        //public string Username { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]  
        public DateTime BirthDate { get; set; }
    }
}
