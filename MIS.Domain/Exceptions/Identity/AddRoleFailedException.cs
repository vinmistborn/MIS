namespace MIS.Domain.Exceptions.Identity
{
    public class AddRoleFailedException : BadRequestException
    {
        public AddRoleFailedException(string role) : base($"Could not create role - *{role}*")
        {

        }

        public AddRoleFailedException(string userName, string role): base ($"Could not add the role *{role}* to *{userName}*")
        {

        }
    }
}
