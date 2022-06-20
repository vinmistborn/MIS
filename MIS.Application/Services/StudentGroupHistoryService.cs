using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MIS.Application.Interfaces.Services;
using MIS.Application.Specifications.AttendanceSpec;
using MIS.Application.Specifications.StudentGroupHistorySpec;
using MIS.Domain.Entities;
using MIS.Shared.Interfaces;

namespace MIS.Application.Services
{
    public class StudentGroupHistoryService : IStudentGroupHistoryService
    {
        private readonly IRepository<StudentGroupHistory> _repo;
        private readonly IRepository<Attendance> _attendanceRepo;
        private readonly IRepository<Student> _studentRepo;

        public StudentGroupHistoryService(IRepository<StudentGroupHistory> repo,
                                          IRepository<Attendance> attendanceRepo,
                                          IRepository<Student> studentRepo)
        {
            _repo = repo;
            _attendanceRepo = attendanceRepo;
            _studentRepo = studentRepo;
        }

        public async Task UpdateFirstLessonAsync()
        {
            var studentsHistory = await _repo.ListAsync(new StudentGroupFirstLessonEmptySpec());
            
            if (studentsHistory.Any())
            {
                foreach (var history in studentsHistory)
                {
                    var studentAttendance = await _attendanceRepo.GetBySpecAsync(new AttendanceFilterStudentSpec(history.StudentId, history.GroupId));
                    if (studentAttendance != null)
                    {
                        history.FirstLesson = studentAttendance.DateTime;
                    }
                }
                await _repo.SaveChangesAsync();
            }            
        }

        public async Task UpdateArchivedStudentHistoryAsync(int studentId)
        {
            var studentsHistory = await _repo.ListAsync(new StudentGroupHistorySpec(studentId));
            await UpdateHistoryAsync(studentsHistory);
        }

        public async Task UpdateGroupCourseHistory(int groupId, int courseId)
        {
            var groupCourseHistory = await _repo.ListAsync(new GroupHistorySpec(groupId, courseId));
            await UpdateHistoryAsync(groupCourseHistory);
        }

        public async Task UpdateHistoryAsync(List<StudentGroupHistory> studentsHistory)
        {
            foreach (var history in studentsHistory)
            {
                var attendanceList = await _attendanceRepo.ListAsync(new AttendanceWithIncludesSpec(history.Student.Id, history.Group.Id));
                var attendance = attendanceList.First();
                history.LastLesson = attendance.DateTime;
                history.IsActive = false;
            }
            await _repo.SaveChangesAsync();
        }

        public async Task UpdateArchivedGroupHistoryAsync(int groupId)
        {
            var groupHistory = await _repo.ListAsync(new GroupHistorySpec(groupId));
            await UpdateHistoryAsync(groupHistory);
        }

       
    }
}
