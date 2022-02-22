using System.ComponentModel.DataAnnotations;

namespace Application.Contracts
{
    public class UserLoginResponseModel
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
