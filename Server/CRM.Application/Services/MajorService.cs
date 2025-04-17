using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Application.Interfaces;
using CRM.Domain.DTOs;
using CRM.Domain.Entities;

namespace CRM.Application.Services
{
    public class MajorService : IMajorService
    {
        private readonly IGenericRepository<Major> _repository;

        public MajorService(IGenericRepository<Major> repository)
        {
            _repository = repository;
        }

        public async Task<MajorDto> GetByIdAsync(int id)
        {
            var major = await _repository.GetByIdAsync(id);
            if (major == null) return null;

            return MapToDto(major);
        }

        public async Task<List<MajorDto>> GetAllAsync()
        {
            var majors = await _repository.GetAllAsync();
            return majors.Select(MapToDto).ToList();
        }

        public async Task<MajorDto> CreateAsync(CreateMajorDto dto)
        {
            var major = new Major
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(major);
            return MapToDto(major);
        }

        public async Task<MajorDto> UpdateAsync(UpdateMajorDto dto)
        {
            var major = await _repository.GetByIdAsync(dto.Id);
            if (major == null) return null;

            major.Name = dto.Name;
            major.Description = dto.Description;
            major.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(major);
            return MapToDto(major);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var major = await _repository.GetByIdAsync(id);
            if (major == null) return false;

            await _repository.DeleteAsync(major);
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.ExistsAsync(id);
        }

        private static MajorDto MapToDto(Major major)
        {
            return new MajorDto
            {
                Id = major.Id,
                CreatedAt = major.CreatedAt,
                UpdatedAt = major.UpdatedAt,
                Name = major.Name,
                Description = major.Description
            };
        }
    }
} 