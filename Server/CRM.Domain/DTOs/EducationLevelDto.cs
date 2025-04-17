using System;

namespace CRM.Domain.DTOs
{
    public class EducationLevelDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateEducationLevelDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateEducationLevelDto : CreateEducationLevelDto
    {
        public int Id { get; set; }
    }
} 