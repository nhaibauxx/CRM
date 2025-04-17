using System.Collections.Generic;

namespace CRM.Domain.Entities
{
    public class EducationLevel : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation properties
        public virtual ICollection<Education> Educations { get; set; }
    }
} 