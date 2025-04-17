using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Application.Interfaces;
using CRM.Domain.DTOs;
using CRM.Domain.Entities;

namespace CRM.Application.Services
{
    public class EducationLevelService : IEducationLevelService
    {
        private readonly IGenericRepository<EducationLevel> _repository;

        public EducationLevelService(IGenericRepository<EducationLevel> repository)
        {
            _repository = repository;
        }

        public async Task<EducationLevelDto> GetByIdAsync(int id)
        {
            var educationLevel = await _repository.GetByIdAsync(id);
            if (educationLevel == null) return null;

            return MapToDto(educationLevel);
        }

        public async Task<List<EducationLevelDto>> GetAllAsync()
        {
            var educationLevels = await _repository.GetAllAsync();
            return educationLevels.Select(MapToDto).ToList();
        }

        public async Task<EducationLevelDto> CreateAsync(CreateEducationLevelDto dto)
        {
            var educationLevel = new EducationLevel
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(educationLevel);
            return MapToDto(educationLevel);
        }

        public async Task<EducationLevelDto> UpdateAsync(UpdateEducationLevelDto dto)
        {
            var educationLevel = await _repository.GetByIdAsync(dto.Id);
            if (educationLevel == null) return null;

            educationLevel.Name = dto.Name;
            educationLevel.Description = dto.Description;
            educationLevel.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(educationLevel);
            return MapToDto(educationLevel);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var educationLevel = await _repository.GetByIdAsync(id);
            if (educationLevel == null) return false;

            await _repository.DeleteAsync(educationLevel);
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.ExistsAsync(id);
        }

        private static EducationLevelDto MapToDto(EducationLevel educationLevel)
        {
            return new EducationLevelDto
            {
                Id = educationLevel.Id,
                CreatedAt = educationLevel.CreatedAt,
                UpdatedAt = educationLevel.UpdatedAt,
                Name = educationLevel.Name,
                Description = educationLevel.Description
            };
        }
    }
} 