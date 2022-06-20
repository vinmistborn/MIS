using System.Collections.Generic;

namespace MIS.Application.DTOs.Group
{
    public class GroupTimetableDTO
    {
        public IEnumerable<int> LessonDays { get; set; }
        public int RoomId { get; set; }
        public int GroupTimeId { get; set; }
    }

    public class UpdateGroupTimetableDTO
    {
        public int[] TimetableIds { get; set; }
    }
}
