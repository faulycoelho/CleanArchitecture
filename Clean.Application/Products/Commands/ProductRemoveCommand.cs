using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public int Id { get; private set; }
        public ProductRemoveCommand(int id)
        {
            this.Id = id;
        }
    }
}
