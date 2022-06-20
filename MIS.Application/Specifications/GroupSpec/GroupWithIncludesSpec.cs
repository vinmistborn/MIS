using Ardalis.Specification;
using MIS.Domain.Entities;

namespace MIS.Application.Specifications.GroupSpec
{
    public class GroupWithIncludesSpec : Specification<Group>, ISingleResultSpecification
    {
        public GroupWithIncludesSpec()
        {
            Query
                .Include(p => p.GroupType)
                .Include(p => p.Course)                
                .Include(p => p.Teachers) 
                .Include(p => p.Students)
                .Include(p => p.StudentGroupHistory)
                .Include(p => p.Timetable)
                .Where(p => p.IsActive == true);
        }

        public GroupWithIncludesSpec(int id) : this()
        {
            Query 
                .Where(p => p.Id == id);
        }
    }
}
