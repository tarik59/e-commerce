using EC_Domain.Entity;
using MediatR;

namespace Application.Mediatr.Command
{
    public class CreateOrderCommand : IRequest<Unit>
    {
        public string userId;
        public CreateOrderCommand(string Id)
        {
            userId = Id;
        }

    }
    public class UpdateOrderCommand : IRequest<Unit>
    {
        public Order order;
        public UpdateOrderCommand(Order o)
        {
            order = o;  
        }

    }
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public int orderId;
        public DeleteOrderCommand(int id)
        {
            orderId = id;
        }

    }
}
