using MIS.Shared;
using System;

namespace MIS.Domain.Entities
{
    public class Timetable : BaseEntity
    {
        public Timetable()
        {

        }

        public Timetable(int lessonDayId,
                         int groupTimeId,
                         int roomId)
        {
            LessonDayId = lessonDayId;
            GroupTimeId = groupTimeId;
            RoomId = roomId;
        }

        public int LessonDayId { get; set; }
        public int GroupTimeId { get; set; }
        public int RoomId { get; set; }
        public int? GroupId { get; set; }       
        public Room Room { get; set; }
        public Group Group { get; set; }
        public LessonDay LessonDay { get; set; }
        public GroupTime GroupTime { get; set; }
    }
}
