using Application.Services;
using EC_Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace EC_Web.Controllers
{
    public class ShoppingCartController : BaseApiController
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly UserManager<AppUser> _userManager;

        public ShoppingCartController(IShoppingCartService shoppingCartService, UserManager<AppUser> userManager)
        {
            _shoppingCartService = shoppingCartService;
            _userManager = userManager;
        }

    }
}
