using Application.Mediatr.Command;
using Application.Mediatr.Query;
using EC_Domain.Entity;
using MediatR;
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
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var query = new GetSingleProductQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            var query = new CreateProductCommand(product);
            var result = await _mediator.Send(query);
            return NoContent();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] Product product)
        {
            var query = new UpdateProductCommand(product);
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
