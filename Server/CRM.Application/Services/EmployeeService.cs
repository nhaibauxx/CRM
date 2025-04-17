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
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _repository;

        public EmployeeService(IGenericRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null) return null;

            return MapToDto(employee);
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();
            return employees.Select(MapToDto).ToList();
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                FullName = dto.FullName,
                BirthDate = dto.BirthDate,
                Gender = dto.Gender,
                EmployeeCode = dto.EmployeeCode,
                DisplayOrder = dto.DisplayOrder,
                Email = dto.Email,
                Phone = dto.Phone,
                ContactAddress = dto.ContactAddress,
                Skype = dto.Skype,
                Facebook = dto.Facebook,
                EmergencyName = dto.EmergencyName,
                EmergencyMobile = dto.EmergencyMobile,
                EmergencyLandline = dto.EmergencyLandline,
                EmergencyRelation = dto.EmergencyRelation,
                EmergencyAddress = dto.EmergencyAddress,
                Country = dto.Country,
                Province = dto.Province,
                District = dto.District,
                Ward = dto.Ward,
                PermanentAddress = dto.PermanentAddress,
                Hometown = dto.Hometown,
                CurrentAddress = dto.CurrentAddress,
                IdentityCard = dto.IdentityCard,
                IdentityCardCreateDate = dto.IdentityCardCreateDate,
                IdentityCardPlace = dto.IdentityCardPlace,
                PassportID = dto.PassportID,
                PassporCreateDate = dto.PassporCreateDate,
                PassporExp = dto.PassporExp,
                PassporPlace = dto.PassporPlace,
                BankHolder = dto.BankHolder,
                BankAccount = dto.BankAccount,
                BankName = dto.BankName,
                BankBranch = dto.BankBranch,
                TaxIdentification = dto.TaxIdentification,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(employee);
            return MapToDto(employee);
        }

        public async Task<EmployeeDto> UpdateAsync(UpdateEmployeeDto dto)
        {
            var employee = await _repository.GetByIdAsync(dto.Id);
            if (employee == null) return null;

            employee.FullName = dto.FullName;
            employee.BirthDate = dto.BirthDate;
            employee.Gender = dto.Gender;
            employee.EmployeeCode = dto.EmployeeCode;
            employee.DisplayOrder = dto.DisplayOrder;
            employee.Email = dto.Email;
            employee.Phone = dto.Phone;
            employee.ContactAddress = dto.ContactAddress;
            employee.Skype = dto.Skype;
            employee.Facebook = dto.Facebook;
            employee.EmergencyName = dto.EmergencyName;
            employee.EmergencyMobile = dto.EmergencyMobile;
            employee.EmergencyLandline = dto.EmergencyLandline;
            employee.EmergencyRelation = dto.EmergencyRelation;
            employee.EmergencyAddress = dto.EmergencyAddress;
            employee.Country = dto.Country;
            employee.Province = dto.Province;
            employee.District = dto.District;
            employee.Ward = dto.Ward;
            employee.PermanentAddress = dto.PermanentAddress;
            employee.Hometown = dto.Hometown;
            employee.CurrentAddress = dto.CurrentAddress;
            employee.IdentityCard = dto.IdentityCard;
            employee.IdentityCardCreateDate = dto.IdentityCardCreateDate;
            employee.IdentityCardPlace = dto.IdentityCardPlace;
            employee.PassportID = dto.PassportID;
            employee.PassporCreateDate = dto.PassporCreateDate;
            employee.PassporExp = dto.PassporExp;
            employee.PassporPlace = dto.PassporPlace;
            employee.BankHolder = dto.BankHolder;
            employee.BankAccount = dto.BankAccount;
            employee.BankName = dto.BankName;
            employee.BankBranch = dto.BankBranch;
            employee.TaxIdentification = dto.TaxIdentification;
            employee.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(employee);
            return MapToDto(employee);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null) return false;

            await _repository.DeleteAsync(employee);
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.ExistsAsync(id);
        }

        private static EmployeeDto MapToDto(Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                CreatedAt = employee.CreatedAt,
                UpdatedAt = employee.UpdatedAt,
                FullName = employee.FullName,
                BirthDate = employee.BirthDate,
                Gender = employee.Gender,
                EmployeeCode = employee.EmployeeCode,
                DisplayOrder = employee.DisplayOrder,
                Email = employee.Email,
                Phone = employee.Phone,
                ContactAddress = employee.ContactAddress,
                Skype = employee.Skype,
                Facebook = employee.Facebook,
                EmergencyName = employee.EmergencyName,
                EmergencyMobile = employee.EmergencyMobile,
                EmergencyLandline = employee.EmergencyLandline,
                EmergencyRelation = employee.EmergencyRelation,
                EmergencyAddress = employee.EmergencyAddress,
                Country = employee.Country,
                Province = employee.Province,
                District = employee.District,
                Ward = employee.Ward,
                PermanentAddress = employee.PermanentAddress,
                Hometown = employee.Hometown,
                CurrentAddress = employee.CurrentAddress,
                IdentityCard = employee.IdentityCard,
                IdentityCardCreateDate = employee.IdentityCardCreateDate,
                IdentityCardPlace = employee.IdentityCardPlace,
                PassportID = employee.PassportID,
                PassporCreateDate = employee.PassporCreateDate,
                PassporExp = employee.PassporExp,
                PassporPlace = employee.PassporPlace,
                BankHolder = employee.BankHolder,
                BankAccount = employee.BankAccount,
                BankName = employee.BankName,
                BankBranch = employee.BankBranch,
                TaxIdentification = employee.TaxIdentification,
                Educations = employee.Educations?.Select(e => new EducationDto
                {
                    Id = e.Id,
                    CreatedAt = e.CreatedAt,
                    UpdatedAt = e.UpdatedAt,
                    EmployeeId = e.EmployeeId,
                    EducationLevelId = e.EducationLevelId,
                    MajorId = e.MajorId,
                    Institution = e.Institution,
                    IssuedDate = e.IssuedDate,
                    Note = e.Note,
                    EducationLevelName = e.EducationLevel?.Name,
                    MajorName = e.Major?.Name
                }).ToList()
            };
        }
    }
} 