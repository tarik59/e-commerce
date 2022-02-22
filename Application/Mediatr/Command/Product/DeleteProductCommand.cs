using Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Command.Product
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int ProductId { get; }
        public DeleteProductCommand(int id)
        {
            ProductId = id;
        }
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.DeleteProductAsync(request.ProductId);
            return Unit.Value;
        }
    }
}
