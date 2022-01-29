using Application.Services;
using EC_Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace EC_Web.Controllers
{
    public class ShoppingCartController : BaseApiController
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
    }
}
