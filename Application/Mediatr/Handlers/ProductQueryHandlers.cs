using Application.Contracts;
using Application.Mediatr.Query;
using Application.Services;
using AutoMapper;
using EC_Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public GetAllProductsHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var orders = await _productService.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(orders);
        }
    }
}
