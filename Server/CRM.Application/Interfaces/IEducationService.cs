using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.DTOs;

namespace CRM.Application.Interfaces
{
    public interface IEducationService
    {
        Task<EducationDto> GetByIdAsync(int id);
        Task<List<EducationDto>> GetAllAsync();
        Task<List<EducationDto>> GetByEmployeeIdAsync(int employeeId);
        Task<EducationDto> CreateAsync(CreateEducationDto dto);
        Task<EducationDto> UpdateAsync(UpdateEducationDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
} 