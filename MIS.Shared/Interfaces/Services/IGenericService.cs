using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.Shared.Interfaces.Services
{
    public interface IGenericService<TEntity, TDto, TInfoDTO> :
                     IGenericServiceInfoSpec<TEntity, TInfoDTO>  where TInfoDTO : class
                                                                 where TDto : class
                                                                 where TEntity : class                                                                            
    {
        Task<IEnumerable<TInfoDTO>> GetAllEntitiesAsync();
        Task<TInfoDTO> GetEntityInfoAsync(int id);
        Task<TDto> GetEntityAsync(int id);
        Task<TInfoDTO> AddEntityAsync(TDto entityDTO);        
        Task<TInfoDTO> UpdateEntityAsync(int id, TDto entityDTO);
        Task DeleteEntity(int id);
    }
}
