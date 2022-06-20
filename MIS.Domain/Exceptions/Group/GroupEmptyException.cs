using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Domain.Exceptions.Group
{
    public class GroupEmptyException : BadRequestException 
    {
        public GroupEmptyException(string groupCode) : base($"Currently group-{groupCode} has no students")
        {

        }
    }
}
