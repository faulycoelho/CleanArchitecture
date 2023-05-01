using Clean.Application.Products.Queries;
using Clean.Domain.Entities;
using Clean.Domain.Interfaces;
using MediatR;

namespace Clean.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAsync(request.Id);
        }
    }
}
