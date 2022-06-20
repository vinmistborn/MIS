using MIS.Domain.Entities.Identity;
using System.Collections.Generic;

namespace MIS.Domain.Entities
{
    public class Teacher : User
    {
        public ICollection<GroupTeacher> GroupTeachers { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
