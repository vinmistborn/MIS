using MIS.Domain.Entities;
using System.Threading.Tasks;

namespace MIS.Application.Interfaces.Services
{
    public interface IGroupCodeService
    {
        Task<string> GetGroupCode(Group group);
    }
}
