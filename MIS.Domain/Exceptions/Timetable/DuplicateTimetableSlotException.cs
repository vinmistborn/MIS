using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Domain.Exceptions.Timetable
{
   public class DuplicateTimetableSlotException : BadRequestException
    {
        public DuplicateTimetableSlotException(string room,
                                               string lessonDay,
                                               string timeSlot) : base($"Specified room - {room} has a time slot at {timeSlot} on {lessonDay} on timetable")
        {

        }
    }
}
