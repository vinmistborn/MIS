using MIS.Domain.Enums;
using System;

namespace MIS.Application.DTOs.Attendance
{
    public class AttendanceInfoDTO
    {
        public int Id { get; set; }
        public string Student { get; set; }
        public string GroupCode { get; set; }
        public DateTime DateTime { get; set; }
        public int SessionNumber { get; set; }        
        public AttendanceStatus AttendanceStatus { get; set; }
    }

}
