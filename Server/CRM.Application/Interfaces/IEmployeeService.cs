using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.DTOs;

namespace CRM.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetByIdAsync(int id);
        Task<List<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto);
        Task<EmployeeDto> UpdateAsync(UpdateEmployeeDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
} 