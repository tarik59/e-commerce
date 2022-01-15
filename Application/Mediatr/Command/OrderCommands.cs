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
}
