using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.DTOs;

namespace CRM.Application.Interfaces
{
    public interface IEducationLevelService
    {
        Task<EducationLevelDto> GetByIdAsync(int id);
        Task<List<EducationLevelDto>> GetAllAsync();
        Task<EducationLevelDto> CreateAsync(CreateEducationLevelDto dto);
        Task<EducationLevelDto> UpdateAsync(UpdateEducationLevelDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
} 