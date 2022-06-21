using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Shared.Exceptions
{
   public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id) : base($"Entity with id-{id} was not found")
        {

        }

        public EntityNotFoundException(string entity, int id) : base($"Entered *{entity}* with id - {id} was not found")
        {

        }

        public EntityNotFoundException() : base($"Entity was not found")
        {

        }

        public EntityNotFoundException(string entity) : base($"{entity} was not found")
        {

        }
    }
}
