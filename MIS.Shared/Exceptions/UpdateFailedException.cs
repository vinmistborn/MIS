using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Shared.Exceptions
{
   public class UpdateFailedException : Exception
    {
        public UpdateFailedException(int id) : base($"Cannot update a user with id - {id}")
        {

        }
    }
}
