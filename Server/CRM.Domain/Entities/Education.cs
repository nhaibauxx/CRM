using System;

namespace CRM.Domain.Entities
{
    public class Education : BaseEntity
    {
        public int EmployeeId { get; set; }
        public int? EducationLevelId { get; set; }
        public int? MajorId { get; set; }
        public string Institution { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string Note { get; set; }

        // Navigation properties
        public virtual Employee Employee { get; set; }
        public virtual EducationLevel EducationLevel { get; set; }
        public virtual Major Major { get; set; }
    }
} 