using EC_Domain.Entity;
using MediatR;

namespace EC_Web.MediatrMiddleware.Command
{
    public class CreateOrderCommand : IRequest<Unit>
    {
        public string userId;
        public CreateOrderCommand(string Id)
        {
            userId = Id;
        }

    }
}
