using Application.Contracts;
using Application.Mediatr.Command;
using Application.Mediatr.Command.ShoppingCart;
using Application.Mediatr.Query;
using Application.Mediatr.Query.ShoppingCart;
using Application.Services;
using EC_Domain.Entity;
using EC_Domain.Identity;
using EC_Web.Extensions;
using EC_Web.Objects.ShoppingCart;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EC_Web.Controllers
{
    [Authorize]
    public class ShoppingCartController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequestModel model)
        {
            var addProductInCartCommand = new AddProductInShoppingCartCommand(User.GetUserId(), model.ProductId);
            await _mediator.Send(addProductInCartCommand);
            return NoContent();
        }
        [HttpPost("deleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductRequestModel model)
        {
            var deleteProductInCartCommand = new DeleteProductInShoppingCartCommand(User.GetUserId(), model.ProductId);
            await _mediator.Send(deleteProductInCartCommand);
            return NoContent();
        }
        [HttpPost("changeProductQuantity")]
        public async Task<IActionResult> ChangeProductQuantity([FromBody] ChangeProductQuantityRequestModel model)
        {
            var changeProductQuantityCommand = new ChangeProductQuantityInShoppingCartCommand(User.GetUserId(), model.ProductId, model.Increasing);
            await _mediator.Send(changeProductQuantityCommand);
            return NoContent();
        }
        [HttpGet("Products")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var getAllProductsFromShoppingCartQuery = new GetAllProductsFromShoppingCartQuery(User.GetUserId());
            var products = await _mediator.Send(getAllProductsFromShoppingCartQuery);
            return Ok(products);
        }
    }
}

