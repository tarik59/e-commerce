using System.ComponentModel.DataAnnotations;

namespace Application.Contracts
{
    public class RegisterUserRequest
    {

        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string UserName { get; set; }
        [StringLength(30, MinimumLength = 5)]
        [Required]
        public string Password { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
