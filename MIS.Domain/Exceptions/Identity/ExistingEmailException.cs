using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Domain.Exceptions.Identity
{
    public class ExistingEmailException : BadRequestException
    {
        public ExistingEmailException(string email) : base($"Email - {email} is already taken by another user")
        {

        }
    }
}
