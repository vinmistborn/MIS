
namespace MIS.Domain.Exceptions.Group
{
    public class GroupFullException : BadRequestException
    {
        public GroupFullException(string groupCode) : base($"Group - *{groupCode}* is full")
        {

        }
    }
}
