using Ardalis.Specification;
using MIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Application.Specifications.GroupSpec
{
    public class GroupWithStudentsSpec : Specification<Group>, ISingleResultSpecification
    {
        public GroupWithStudentsSpec()
        {
            Query
                .Include(p => p.StudentGroupHistory);
        }

        public GroupWithStudentsSpec(int id) : this()
        {
            Query                
                .Where(p => p.Id == id);
        }
    }
}
