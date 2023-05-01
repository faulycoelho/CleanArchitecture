using Clean.Application.Products.Commands;
using Clean.Domain.Entities;
using Clean.Domain.Interfaces;
using MediatR;

namespace Clean.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(request.Id);
            if (product == null)
            {
                throw new ApplicationException("Error could not be found.");
            }
            else
            {
                return await _productRepository.DeleteAsync(product);
            }
        }
    }
}
