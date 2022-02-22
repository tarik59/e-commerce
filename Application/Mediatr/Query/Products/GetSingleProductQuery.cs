using Application.Contracts;
using Application.Repositories;
using AutoMapper;
using EC_Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Query.Products
{
    public class GetSingleProductQuery : IRequest<ProductDto>
    {
        public int ProductId;
        public GetSingleProductQuery(int id)
        {
            ProductId = id;
        }
    }
    public class GetSingleProductQueryHandler : IRequestHandler<GetSingleProductQuery, ProductDto>
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public GetSingleProductQueryHandler(IMapper mapper, IRepository<Product> productRepo)
        {
            _mapper = mapper;
            _productRepo = productRepo;
        }

        public async Task<ProductDto> Handle(GetSingleProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.Get(request.ProductId);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
