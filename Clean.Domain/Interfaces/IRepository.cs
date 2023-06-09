﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Domain.Interfaces
{
    public interface IRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<T> CreateAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task<T> DeleteAsync(T obj);
    }
}
