namespace MIS.Domain.Exceptions.Timetable
{
    public class GroupNotFoundException : BadRequestException
    {
        public GroupNotFoundException() : base("Specified group was not found in the timetable")
        {

        }
    }
}
