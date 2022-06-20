
namespace MIS.Application.DTOs.Timetable
{
    public class UpdateTimetableDTO
    {
        public int Id { get; set; }
        public int LessonDayId { get; set; }
        public int GroupTimeId { get; set; }
        public int RoomId { get; set; }
    }
}
