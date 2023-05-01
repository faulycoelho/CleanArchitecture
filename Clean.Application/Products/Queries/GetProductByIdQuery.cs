using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; private set; }
        public GetProductByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
