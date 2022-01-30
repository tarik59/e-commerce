using Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediatr.Query
{
    public class LoginUserQuery : IRequest<UserDto>
    {
        public LoginDto loginDto;

        public LoginUserQuery(LoginDto loginDto)
        {
            this.loginDto = loginDto;
        }
    }
}
