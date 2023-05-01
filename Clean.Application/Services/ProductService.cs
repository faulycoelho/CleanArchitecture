using AutoMapper;
using Clean.Application.DTOs;
using Clean.Application.Interfaces;
using Clean.Application.Products.Commands;
using Clean.Application.Products.Queries;
using MediatR;

namespace Clean.Application.Services
{
    public class ProductService : IProductService
    {
        readonly IMediator _mediator;
        readonly IMapper _mapper;
        public ProductService(IMediator mediator, IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var productQuery = new GetProductsQuery();
            var entities = await _mediator.Send(productQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(entities);
        }

        public async Task<ProductDTO> GetAsync(int id)
        {
            var productQuery = new GetProductByIdQuery(id);
            var entity = await _mediator.Send(productQuery);
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task AddAsync(ProductDTO Dto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(Dto);
            await _mediator.Send(productCreateCommand);
        }

        public async Task UpdateAsync(ProductDTO Dto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(Dto);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task DeleteAsync(int id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id);
            await _mediator.Send(productRemoveCommand);
        }
    }
}
