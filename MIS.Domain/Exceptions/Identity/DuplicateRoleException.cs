using System;

namespace MIS.Domain.Exceptions.Identity
{
    public class DuplicateRoleException : BadRequestException
    {
        public DuplicateRoleException(string role) : base($"Role - *{role}* already exists")
        {

        }
    }
}
