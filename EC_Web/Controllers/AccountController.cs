using Application.Contracts;
using Application.Mediatr.Command;
using Application.Services;
using EC_Domain.Identity;
using EC_Repository;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EC_Web.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mediator = mediator;
        }
        [HttpPost("register")] 
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registerDto)
        {
            var command = new RegisterUserCommand(registerDto);
            var user = await _mediator.Send(command);
            return user; 
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(user => user.UserName == loginDto.UserName.ToLower());

            if (user == null)
            {
                return Unauthorized("Invalid username");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized();

            return new UserDto
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };
        }
    }
}
