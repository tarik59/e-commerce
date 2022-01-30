using Application.Contracts;
using Application.Mediatr.Query;
using Application.Services;
using EC_Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Handlers
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, UserDto>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public LoginQueryHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<UserDto> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(user => user.UserName == request.loginDto.UserName.ToLower());

            if (user == null)
            {
                throw new Exception("Invalid username");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.loginDto.Password, false);

            if (!result.Succeeded) throw new Exception("Unauthorized");

            return new UserDto
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };
        }
    }
}
