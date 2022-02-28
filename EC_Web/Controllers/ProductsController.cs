using Application.Contracts;
using Application.Mediatr.Command;
using Application.Mediatr.Command.Product;
using Application.Mediatr.Command.Products;
using Application.Mediatr.Query;
using Application.Mediatr.Query.Products;
using EC_Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EC_Web.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var query = new GetSingleProductQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDto product)
        {
            var command = new CreateProductCommand(product);
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{productId}")]
        public async Task<ActionResult> Put(int productId, [FromBody] ProductDto product)
        {
            var query = new UpdateProductCommand(productId, product);
            var result = await _mediator.Send(query);
            return NoContent();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var query = new DeleteProductCommand(id);
            var result = await _mediator.Send(query);
            return NoContent();
        }
    }
}
