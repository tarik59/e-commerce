using Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediatr.Query
{
    public class LoginQuery : IRequest<UserDto>
    {
        public LoginDto loginDto;

        public LoginQuery(LoginDto loginDto)
        {
            this.loginDto = loginDto;
        }
    }
}
