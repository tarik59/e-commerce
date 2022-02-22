using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public class OrderDto
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public int statusId { get; set; } = 1;
        public StatusDto Status { get; set; }
        public ICollection<ProductDto> products { get; set; }
    }
}
