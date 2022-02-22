using System.ComponentModel.DataAnnotations;

namespace Application.Contracts
{
    public class LoginUserRequest

    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
