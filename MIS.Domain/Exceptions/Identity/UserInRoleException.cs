namespace MIS.Domain.Exceptions.Identity
{
    public class UserInRoleException : BadRequestException
    {
        public UserInRoleException(string userName, string roleName) : base($"The user {userName} is already assigned to {roleName} role")
        {

        }
    }
}
