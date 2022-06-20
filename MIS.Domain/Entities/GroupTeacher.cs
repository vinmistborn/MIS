namespace MIS.Domain.Entities
{
   public class GroupTeacher
    {
        public GroupTeacher()
        {

        }
        public GroupTeacher(Group group, Teacher teacher)
        {
            Group = group;
            Teacher = teacher;
        }
        public Group Group { get; set; }
        public Teacher Teacher { get; set; }
    }
}
