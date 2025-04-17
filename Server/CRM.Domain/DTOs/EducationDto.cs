using System;

namespace CRM.Domain.DTOs
{
    public class EducationDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int EmployeeId { get; set; }
        public int? EducationLevelId { get; set; }
        public int? MajorId { get; set; }
        public string Institution { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string Note { get; set; }

        // Related data
        public string EducationLevelName { get; set; }
        public string MajorName { get; set; }
    }

    public class CreateEducationDto
    {
        public int EmployeeId { get; set; }
        public int? EducationLevelId { get; set; }
        public int? MajorId { get; set; }
        public string Institution { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string Note { get; set; }
    }

    public class UpdateEducationDto : CreateEducationDto
    {
        public int Id { get; set; }
    }
} 