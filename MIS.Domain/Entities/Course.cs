using MIS.Shared;
using System.Collections.Generic;

namespace MIS.Domain.Entities
{
    public class Course : BaseEntity
    {       
        public string Name { get; set; }
        public string CourseLevel { get; set; }
        public string CourseDuration { get; set; }
        public decimal Fee { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
