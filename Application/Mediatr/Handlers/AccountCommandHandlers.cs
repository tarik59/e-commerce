using Application.Contracts;
using Application.Mediatr.Command;
using Application.Services;
using EC_Domain.Identity;
using Mapster;
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
    public class RegisterCommandHandler : IRequestHandler<RegisterUserCommand, UserDto>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public RegisterCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userManager.Users.AnyAsync(u => u.UserName == request.registerDto.UserName.ToLower()))
            {
                throw new Exception("Account with that username already exists");
            }
            var user = request.registerDto.Adapt<AppUser>();
            user.UserName = request.registerDto.UserName.ToLower();

            var registerResult = await _userManager.CreateAsync(user, request.registerDto.Password);
            if (!registerResult.Succeeded)
            {
                throw new Exception(registerResult.Errors.ToString());
            }
            var roleResult = await _userManager.AddToRoleAsync(user, "Member");
            if (!roleResult.Succeeded)
            {
                throw new Exception(registerResult.Errors.ToString());
            }

            return new UserDto
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };
        }
    }
}
