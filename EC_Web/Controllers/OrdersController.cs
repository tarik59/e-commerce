using Application.Mediatr.Command;
using Application.Mediatr.Query;
using EC_Domain.Entity;
using EC_Repository;
using EC_Web.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC_Web.Controllers
{
    [Authorize]
    public class OrdersController : BaseApiController
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Getorders()
        {
            var query = new GetAllOrdersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var query = new GetSingleOrderQuery(id);
            var result = await _mediator.Send(query);
            return (result != null) ? Ok(result) : new NotFoundResult();
        }

        // PUT: api/Orders/5
        [HttpPut]
        public async Task<ActionResult> PutOrder(Order order)
        {
            var query = new UpdateOrderCommand(order);
            var result = await _mediator.Send(query);
            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder()
        {
            var query = new CreateOrderCommand(User.GetUserId());
            var result = await _mediator.Send(query);
            return NoContent();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var query = new DeleteOrderCommand(id);
            var result = await _mediator.Send(query);

            return NoContent();
        }
    }
}
