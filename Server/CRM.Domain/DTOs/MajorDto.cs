using System;

namespace CRM.Domain.DTOs
{
    public class MajorDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateMajorDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateMajorDto : CreateMajorDto
    {
        public int Id { get; set; }
    }
} 