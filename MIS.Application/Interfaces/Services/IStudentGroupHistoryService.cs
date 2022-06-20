using MIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Application.Interfaces.Services
{
    public interface IStudentGroupHistoryService
    {
        Task UpdateFirstLessonAsync();
        Task UpdateArchivedStudentHistoryAsync(int studentId);
        Task UpdateArchivedGroupHistoryAsync(int groupId);
        Task UpdateGroupCourseHistory(int groupId, int courseId);
    }
}
