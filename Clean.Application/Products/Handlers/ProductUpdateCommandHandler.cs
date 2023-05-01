using Clean.Application.Products.Commands;
using Clean.Domain.Entities;
using Clean.Domain.Interfaces;
using MediatR;

namespace Clean.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(request.Id);
            if (product == null)
            {
                throw new ApplicationException("Error could not be found.");
            }
            else
            {
                product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
                return await _productRepository.UpdateAsync(product);
            }
        }
    }
}
