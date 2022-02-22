using Application.Contracts;
using Application.Mediatr.Command;
using Application.Mediatr.Command.Order;
using Application.Mediatr.Query;
using Application.Mediatr.Query.Orders;
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
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var query = new GetAllOrdersForLoggedInUserQuery(User.GetUserId());
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var query = new GetSingleOrderQuery(User.GetUserId(), id);
            var result = await _mediator.Send(query);
            return (result != null) ? Ok(result) : new NotFoundResult();
        }

        // PUT: api/Orders/5
       /* Ne treba nam momentalno, da vidim da li poslen da ga dodam!
        * [HttpPut]
        public async Task<ActionResult> PutOrder(int orderId, OrderDto order)
        {
            var query = new UpdateOrderCommand(_userId, orderId, order);
            await _mediator.Send(query);
            return NoContent();
        }
*/
        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder()
        {
            var query = new CreateOrderCommand(User.GetUserId());
            await _mediator.Send(query);
            return NoContent();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var query = new DeleteOrderCommand(id);
            await _mediator.Send(query);

            return NoContent();
        }
    }
}
