namespace MIS.Domain.Exceptions.Room
{
    public class RoomBookedException: BadRequestException
    {
        public RoomBookedException() : base("there is a group registered for this room")
        {

        }

        //public RoomBookedException(string day) : base($"There is a group registered on {day} for this room")
        //{

        //}

        public RoomBookedException(string groupCode) : base($"Group - {groupCode} already assigned to this timetable slot")
        {

        }
    }
}
