using Ardalis.Specification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.Shared.Interfaces.Services
{
    public interface IGenericServiceInfoSpec<TEntity, TInfoDTO> where TInfoDTO : class
                                                                where TEntity : class
    {
        Task<IEnumerable<TInfoDTO>> GetAllEntitiesSpecAsync(Specification<TEntity> specification);
        Task<TInfoDTO> GetEntityInfoSpecAsync<Spec>(Spec specification) where Spec : ISpecification<TEntity>, ISingleResultSpecification;
    }
}
