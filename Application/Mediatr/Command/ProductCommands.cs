using EC_Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediatr.Command
{
    public class CreateProductCommand : IRequest<Unit>
    {
        public Product Product;
        public CreateProductCommand(Product product)
        {
           Product = product;
        }

    }
    public class UpdateProductCommand : IRequest<Unit>
    {
        public Product Product;
        public UpdateProductCommand(Product o)
        {
            Product = o;
        }

    }
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int ProductId;
        public DeleteProductCommand(int id)
        {
            ProductId = id;
        }

    }
}
