using Application.Contracts;
using Application.Mediatr.Command;
using Application.Mediatr.Command.Account;
using Application.Mediatr.Query;
using Application.Mediatr.Query.Account;
using Application.Services;
using EC_Domain.Identity;
using EC_Repository;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EC_Web.Controllers
{
    public class TestObj
    {
        public List<TestDto> list { get; set; }
    }
   public class TestDto
    {
        public string Id { get; set; } 
        public string Name { get; set; }
    }

    public class AccountController : BaseApiController
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")] 
        public async Task<ActionResult<UserLoginResponseModel>> Register([FromBody] RegisterUserRequest registerDto)
        {
            var command = new RegisterUserCommand(registerDto);
            var user = await _mediator.Send(command);
            return user; 
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserLoginResponseModel>> Login(LoginUserRequest loginDto)
        {
            var query = new LoginUserQuery(loginDto);
            var user = await _mediator.Send(query);
            return user;
        }
    }
}
