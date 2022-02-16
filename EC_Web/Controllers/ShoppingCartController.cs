using Application.Contracts;
using Application.Mediatr.Command;
using Application.Mediatr.Query;
using Application.Services;
using EC_Domain.Entity;
using EC_Domain.Identity;
using EC_Web.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EC_Web.Controllers
{
    public class ShoppingCartController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("addProduct/{productId}")]
        public async Task<IActionResult> AddProduct(int productId)
        {
            var addProductInCartCommand = new AddProductInShoppingCartCommand(User.GetUserId(), productId);
            await _mediator.Send(addProductInCartCommand);
            return NoContent();
        }
        [HttpPost("deleteProduct/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var deleteProductInCartCommand = new DeleteProductInShoppingCartCommand(User.GetUserId(), productId);
            await _mediator.Send(deleteProductInCartCommand);
            return NoContent();
        }
        [HttpPut("changeProductQuantity/{productId}")]
        public async Task<IActionResult> ChangeProductQuantity(int productId, bool increasing)
        {
            var changeProductQuantityCommand = new ChangeProductQuantityInShoppingCartCommand(User.GetUserId(), productId, increasing);
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

