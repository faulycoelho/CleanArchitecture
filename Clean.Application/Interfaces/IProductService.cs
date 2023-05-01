using Clean.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<ProductDTO> GetAsync(int id);
        Task AddAsync(ProductDTO Dto);
        Task UpdateAsync(ProductDTO Dto);
        Task DeleteAsync(int id);
    }
}
