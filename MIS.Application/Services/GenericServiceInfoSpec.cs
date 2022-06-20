using Ardalis.Specification;
using AutoMapper;
using MIS.Shared.Interfaces.Services;
using MIS.Shared.Exceptions;
using MIS.Shared.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.Application.Services
{
    public class GenericServiceInfoSpec<TEntity, TInfoDTO> : IGenericServiceInfoSpec<TEntity, TInfoDTO> where TInfoDTO : class
                                                                                                        where TEntity : class
    {
        protected readonly IRepository<TEntity> _repo;
        protected readonly IMapper _mapper;

        public GenericServiceInfoSpec(IRepository<TEntity> repo,
                                  IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public virtual async Task<IEnumerable<TInfoDTO>> GetAllEntitiesSpecAsync(Specification<TEntity> specification)
        {
            var entities = await _repo.ListAsync(specification);
            return _mapper.Map<IEnumerable<TInfoDTO>>(entities);
        }

        public virtual async Task<TInfoDTO> GetEntityInfoSpecAsync<Spec>(Spec specification) where Spec : ISpecification<TEntity>, ISingleResultSpecification
        {
            var entity = await _repo.GetBySpecAsync(specification);

            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            return _mapper.Map<TInfoDTO>(entity);
        }
    }
}
