using Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediatr.Command
{
    public class RegisterUserCommand : IRequest<UserDto>
    {
        public RegisterDto registerDto;
        public RegisterUserCommand(RegisterDto registerDto)
        {
            this.registerDto = registerDto;
        }
    }
}
