using Clean.Application.DTOs;
using Clean.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Interfaces
{
    public interface ICategoryService  
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO> GetAsync(int id);
        Task AddAsync(CategoryDTO Dto);
        Task UpdateAsync(CategoryDTO Dto);
        Task DeleteAsync(int id);
    }
}
