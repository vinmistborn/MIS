using MIS.Shared;
using System.Collections.Generic;

namespace MIS.Domain.Entities
{
    public class Group : BaseEntity
    {
        public int GroupTypeId { get; set; }
        public string Code { get; set; }
        public decimal Fee { get; set; } 
        public int Capacity { get; set; }        
        public bool IsActive { get; set; }
        public int? NumOfStudents { get; set; }
        public int CourseId { get; set; } 
        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<GroupTeacher> GroupTeachers { get; set; }
        public ICollection<Timetable> Timetable { get; set; }
        public GroupType GroupType { get; set; }
        public Course Course { get; set; }  
        public ICollection<StudentGroupHistory> StudentGroupHistory { get; set; }
    }
}
