using MIS.Domain.Enums;
using MIS.Shared;
using System;
using System.Collections.Generic;

namespace MIS.Domain.Entities
{
    public class Attendance : BaseEntity
    {
        public Attendance()
        {

        }

        public Attendance(DateTime dateTime,
                          int sessionNumber,                         
                          int studentId,
                          int groupId)
        {
            DateTime = dateTime;
            SessionNumber = sessionNumber;
            AttendanceStatus = AttendanceStatus.Present;
            StudentId = studentId;
            GroupId = groupId;
        }

        public DateTime DateTime { get; set; }
        public int SessionNumber { get; set; }
        public AttendanceStatus AttendanceStatus { get; set; }
        public int? StudentId { get; set; }
        public int? GroupId { get; set; }
        public Student Student { get; set; }
        public Group Group { get; set; }
    }
}
