using MIS.Domain.Enums;

namespace MIS.Application.DTOs.Attendance
{
    public class UpdateAttendanceDTO
    {
        public int Id { get; set; }
        public AttendanceStatus AttendanceStatus { get; set; }
    }
}
