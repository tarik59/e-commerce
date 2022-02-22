using Application.Contracts;
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

namespace Application.Mediatr.Query.Account
{
    public class LoginUserQuery : IRequest<UserLoginResponseModel>
    {
        public LoginUserRequest loginDto;

        public LoginUserQuery(LoginUserRequest loginDto)
        {
            this.loginDto = loginDto;
        }
    }
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, UserLoginResponseModel>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public LoginUserQueryHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }
        public async Task<UserLoginResponseModel> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(user => user.UserName == request.loginDto.UserName.ToLower());

            if (user == null)
            {
                throw new Exception("Invalid username");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.loginDto.Password, false);

            if (!result.Succeeded) throw new Exception("Unauthorized");

            return new UserLoginResponseModel
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };
        }
    }
}
