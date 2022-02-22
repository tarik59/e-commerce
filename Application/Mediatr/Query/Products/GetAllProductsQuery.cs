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
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {

    }

    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IRepository<Product> _productsRepository;
        private readonly IMapper _mapper;
        public GetAllProductsHandler(IRepository<Product> productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productsRepository.GetAll(new string[] { "Brand", "TypeOfProduct", "Gender" });
            products.Where(c => c.Quantity > 0);
            return _mapper.Map<IEnumerable<ProductDto>>(products.ToList());
        }
    }

}
