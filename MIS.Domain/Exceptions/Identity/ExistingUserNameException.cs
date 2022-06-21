namespace MIS.Domain.Exceptions.Identity
{
    public class ExistingUserNameException : BadRequestException
    {
        public ExistingUserNameException(string username) : base($"Username - {username} is not available for use")
        {

        }
    }
}
