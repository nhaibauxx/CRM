using System;
using System.Collections.Generic;

namespace CRM.Domain.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Thông tin cơ bản
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        public string EmployeeCode { get; set; }
        public int DisplayOrder { get; set; }

        // Liên hệ
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContactAddress { get; set; }
        public string Skype { get; set; }
        public string Facebook { get; set; }

        // Liên hệ khẩn cấp
        public string EmergencyName { get; set; }
        public string EmergencyMobile { get; set; }
        public string EmergencyLandline { get; set; }
        public string EmergencyRelation { get; set; }
        public string EmergencyAddress { get; set; }

        // Địa chỉ
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string PermanentAddress { get; set; }
        public string Hometown { get; set; }
        public string CurrentAddress { get; set; }

        // Định danh
        public string IdentityCard { get; set; }
        public DateTime? IdentityCardCreateDate { get; set; }
        public string IdentityCardPlace { get; set; }
        public string PassportID { get; set; }
        public DateTime? PassporCreateDate { get; set; }
        public DateTime? PassporExp { get; set; }
        public string PassporPlace { get; set; }

        // Ngân hàng
        public string BankHolder { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }

        // Khác
        public string TaxIdentification { get; set; }

        // Related data
        public List<EducationDto> Educations { get; set; }
    }

    public class CreateEmployeeDto
    {
        // Thông tin cơ bản
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        public string EmployeeCode { get; set; }
        public int DisplayOrder { get; set; }

        // Liên hệ
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContactAddress { get; set; }
        public string Skype { get; set; }
        public string Facebook { get; set; }

        // Liên hệ khẩn cấp
        public string EmergencyName { get; set; }
        public string EmergencyMobile { get; set; }
        public string EmergencyLandline { get; set; }
        public string EmergencyRelation { get; set; }
        public string EmergencyAddress { get; set; }

        // Địa chỉ
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string PermanentAddress { get; set; }
        public string Hometown { get; set; }
        public string CurrentAddress { get; set; }

        // Định danh
        public string IdentityCard { get; set; }
        public DateTime? IdentityCardCreateDate { get; set; }
        public string IdentityCardPlace { get; set; }
        public string PassportID { get; set; }
        public DateTime? PassporCreateDate { get; set; }
        public DateTime? PassporExp { get; set; }
        public string PassporPlace { get; set; }

        // Ngân hàng
        public string BankHolder { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }

        // Khác
        public string TaxIdentification { get; set; }
    }

    public class UpdateEmployeeDto : CreateEmployeeDto
    {
        public int Id { get; set; }
    }
} 