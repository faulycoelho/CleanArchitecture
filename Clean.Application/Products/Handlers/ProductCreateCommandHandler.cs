using Clean.Application.Products.Commands;
using Clean.Domain.Entities;
using Clean.Domain.Interfaces;
using MediatR;

namespace Clean.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);
            if (product == null)
            {
                throw new ApplicationException("Error creating entity");
            }
            else
            {
                product.CategoryId = request.CategoryId;
                return await _productRepository.CreateAsync(product);
            }
        }
    }
}
