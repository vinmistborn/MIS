using System.Collections.Generic;
using System.Threading.Tasks;
using MIS.Application.DTOs.Attendance;
using MIS.Domain.Entities;
using MIS.Shared.Interfaces.Services;

namespace MIS.Application.Interfaces.Services
{
    public interface IAttendanceService : IGenericService<Attendance, AttendanceDTO, AttendanceInfoDTO>
    {
        public Task<IEnumerable<AttendanceInfoDTO>> AddAttendanceListAsync(AddAttendanceDTO attendanceDTO);
        public Task<AttendanceInfoDTO> UpdateStudentAttendanceAsync(int id, UpdateAttendanceDTO attendanceDTO);
        public Task<IEnumerable<AttendanceInfoDTO>> GetStudentAttendance(int studentId);
        public Task<IEnumerable<AttendanceInfoDTO>> GetGroupAttendance(int groupId);
    }
}
