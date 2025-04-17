using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Application.Interfaces;
using CRM.Domain.DTOs;
using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.Application.Services
{
    public class EducationService : IEducationService
    {
        private readonly IGenericRepository<Education> _repository;

        public EducationService(IGenericRepository<Education> repository)
        {
            _repository = repository;
        }

        public async Task<EducationDto> GetByIdAsync(int id)
        {
            var education = await _repository.GetByIdAsync(id);
            if (education == null) return null;

            return MapToDto(education);
        }

        public async Task<List<EducationDto>> GetAllAsync()
        {
            var educations = await _repository.GetAllAsync();
            return educations.Select(MapToDto).ToList();
        }

        public async Task<List<EducationDto>> GetByEmployeeIdAsync(int employeeId)
        {
            var educations = await _repository.FindAsync(e => e.EmployeeId == employeeId);
            return educations.Select(MapToDto).ToList();
        }

        public async Task<EducationDto> CreateAsync(CreateEducationDto dto)
        {
            var education = new Education
            {
                EmployeeId = dto.EmployeeId,
                EducationLevelId = dto.EducationLevelId,
                MajorId = dto.MajorId,
                Institution = dto.Institution,
                IssuedDate = dto.IssuedDate,
                Note = dto.Note,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(education);
            return MapToDto(education);
        }

        public async Task<EducationDto> UpdateAsync(UpdateEducationDto dto)
        {
            var education = await _repository.GetByIdAsync(dto.Id);
            if (education == null) return null;

            education.EmployeeId = dto.EmployeeId;
            education.EducationLevelId = dto.EducationLevelId;
            education.MajorId = dto.MajorId;
            education.Institution = dto.Institution;
            education.IssuedDate = dto.IssuedDate;
            education.Note = dto.Note;
            education.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(education);
            return MapToDto(education);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var education = await _repository.GetByIdAsync(id);
            if (education == null) return false;

            await _repository.DeleteAsync(education);
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.ExistsAsync(id);
        }

        private static EducationDto MapToDto(Education education)
        {
            return new EducationDto
            {
                Id = education.Id,
                CreatedAt = education.CreatedAt,
                UpdatedAt = education.UpdatedAt,
                EmployeeId = education.EmployeeId,
                EducationLevelId = education.EducationLevelId,
                MajorId = education.MajorId,
                Institution = education.Institution,
                IssuedDate = education.IssuedDate,
                Note = education.Note,
                EducationLevelName = education.EducationLevel?.Name,
                MajorName = education.Major?.Name
            };
        }
    }
} 