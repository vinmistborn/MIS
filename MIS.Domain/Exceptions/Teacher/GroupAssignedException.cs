namespace MIS.Domain.Exceptions.Teacher
{
    public class GroupAssignedException : BadRequestException
    {
        public GroupAssignedException(string groupCode, string teacher) :  base($"Group {groupCode} is already assigned to {teacher}")
        {

        }
    }
}
