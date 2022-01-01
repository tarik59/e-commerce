using EC_Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC_Domain.Entity
{
    public class Order:BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; }
        public int statusId { get; set; }
        public Status Status { get; set; }
        public int userId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<Product> products { get; set; }
    }
}
