using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Domain.Exceptions.Timetable
{
    public class TeacherBookedException : BadRequestException
    {
        public TeacherBookedException(string teacher) : base($"{teacher} has a group on specified days and time")
        {

        }
    }
}
