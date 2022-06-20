using MIS.Domain.Entities;
using MIS.Application.Interfaces.Repositories;
using MIS.Application.Specifications.GroupSpec;
using MIS.Shared.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.Infrastructure.Data.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Group>> GetFinishedGroups()
        {
            return await ListAsync(new GroupFinishedSpec());
        }

        public async Task<IEnumerable<Group>> GetCourseGroups(int courseId)
        {
            return await ListAsync(new GroupWithCourseFilterSpec(courseId));
        }

        public async Task<IEnumerable<Group>> GetTeacherGroups(int teacherId)
        {
            var teacher = await _context.Teachers.FindAsync(teacherId);
            return await ListAsync(new GroupWithTeacherFilterSpec(teacher));
        }
    }
}
