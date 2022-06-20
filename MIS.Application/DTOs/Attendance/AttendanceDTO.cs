using MIS.Domain.Enums;
using System;

namespace MIS.Application.DTOs.Attendance
{
    public class AttendanceDTO
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int SessionNumber { get; set; }
        public AttendanceStatus AttendanceStatus { get; set; }
        public int StudentId { get; set; } 
        public int GroupId { get; set; }
    }
}
