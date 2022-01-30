using Application.Contracts;
using Application.Mediatr.Command;
using Application.Mediatr.Query;
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
            var query = new LoginUserQuery(loginDto);
            var user = await _mediator.Send(query);
            return user;
        }
    }
}
