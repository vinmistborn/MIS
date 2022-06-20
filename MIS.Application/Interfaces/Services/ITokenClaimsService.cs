using MIS.Domain.Entities.Identity;
using System.Threading.Tasks;

namespace MIS.Application.Interfaces.Services
{
    public interface ITokenClaimsService
    {
        Task<string> GetTokenAsync(User appUser);
    }
}
