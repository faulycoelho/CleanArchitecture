﻿using AutoMapper;
using Clean.Application.DTOs;
using Clean.Application.Interfaces;
using Clean.Domain.Entities;
using Clean.Domain.Interfaces;

namespace Clean.Application.Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _repository;
        readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(entities);
        }

        public async Task<CategoryDTO> GetAsync(int id)
        {
            var entity = await _repository.GetAsync(id);
            return _mapper.Map<CategoryDTO>(entity);
        }

        public async Task AddAsync(CategoryDTO Dto)
        {
            var entity = _mapper.Map<Category>(Dto);
            await _repository.CreateAsync(entity);
        }

        public async Task UpdateAsync(CategoryDTO Dto)
        {
            var entity = _mapper.Map<Category>(Dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetAsync(id);
            await _repository.DeleteAsync(entity);
        }
    }
}
