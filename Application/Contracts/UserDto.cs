using System.ComponentModel.DataAnnotations;

namespace Application.Contracts
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
