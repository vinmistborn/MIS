using Microsoft.AspNetCore.Identity;

namespace MIS.Domain.Entities.Identity
{
    public class Role : IdentityRole<int>
    {
        public Role()
        {

        }

        public Role(string role) : base(role)
        {

        }
    }
}
