using MIS.Shared;
using System;

namespace MIS.Domain.Entities
{
    public class StudentGroupHistory : BaseEntity
    {
        public StudentGroupHistory()
        {

        }
        public StudentGroupHistory(int studentId, int groupId, int courseId)
        {
            StudentId = studentId;
            GroupId = groupId;
            CourseId = courseId;
            IsActive = true;
        }

        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public int? CourseId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? FirstLesson { get; set; }
        public DateTime? LastLesson { get; set; }        
        public Student Student { get; set; }
        public Group Group { get; set; }
        public Course Course { get; set; }
    }
}
