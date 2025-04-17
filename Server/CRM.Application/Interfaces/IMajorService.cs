using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.DTOs;

namespace CRM.Application.Interfaces
{
    public interface IMajorService
    {
        Task<MajorDto> GetByIdAsync(int id);
        Task<List<MajorDto>> GetAllAsync();
        Task<MajorDto> CreateAsync(CreateMajorDto dto);
        Task<MajorDto> UpdateAsync(UpdateMajorDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
} 