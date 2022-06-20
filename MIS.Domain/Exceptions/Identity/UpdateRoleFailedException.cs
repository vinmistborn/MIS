namespace MIS.Domain.Exceptions.Identity
{
    public class UpdateRoleFailedException : BadRequestException
    {
        public UpdateRoleFailedException(string role) : base($"Could not change the role into *{role}*")
        {

        }
    }
}
