using EC_Repository;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EC_Web.Controllers
{
    public class UserDto
    {
        public string Username { get; set; }
        public string UserName { get; set; }
    }
    public class AccountController : BaseApiController
    {
        public readonly ApplicationDbContext _db;

        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult<UserDto> TestMapster(int id)
        {
            return  _db.Users.Find(id).Adapt<UserDto>();
        }

    }
}
