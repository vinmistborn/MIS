using System;

namespace MIS.Domain.Exceptions.Identity
{
   public class InvalidPasswordException : BadRequestException
    {
        public InvalidPasswordException(string message) : 
                                        base(message)
        {

        }
    }

    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string email) : base($"There is no registered user with email - {email}")
        {

        }
    }
}
