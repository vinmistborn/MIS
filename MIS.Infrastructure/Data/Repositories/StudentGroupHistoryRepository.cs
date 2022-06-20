using MIS.Application.Interfaces.Repositories;
using MIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Infrastructure.Data.Repositories
{
    public class StudentGroupHistoryRepository : Repository<StudentGroupHistory>, IStudentGroupHistoryRepository
    {
        public StudentGroupHistoryRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddHistory(int studentId, int groupId, int courseId)
        {
            var studentHistory = new StudentGroupHistory(studentId, groupId, courseId);
            await AddAsync(studentHistory);
        }
    }
}
