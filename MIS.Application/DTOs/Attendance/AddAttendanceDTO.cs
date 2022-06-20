using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Application.DTOs.Attendance
{
    public class AddAttendanceDTO
    {
        public int GroupId { get; set; }
        public DateTime DateTime { get; set; }
        public int SessionNumber { get; set; }
    }
}
