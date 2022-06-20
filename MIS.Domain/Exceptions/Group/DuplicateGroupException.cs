namespace MIS.Domain.Exceptions.Group
{
    public class DuplicateGroupException : BadRequestException
    {
        public DuplicateGroupException(string studentName, string groupCode) 
                                      : base($"Group - *{groupCode}* was already added to {studentName}")
        {

        }
    }
}
