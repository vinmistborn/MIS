using AutoMapper;
using MIS.Shared.Interfaces.Services;
using MIS.Shared;
using MIS.Shared.Exceptions;
using MIS.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.Application.Services
{
    public class GenericService<TEntity, TDto, TInfoDTO> : GenericServiceInfoSpec<TEntity, TInfoDTO> ,
                                                           IGenericService<TEntity, TDto, TInfoDTO> where TInfoDTO : class
                                                                                                    where TDto : class
                                                                                                    where TEntity : BaseEntity
                                                                                        
    {
        public GenericService(IRepository<TEntity> repo,
                              IMapper mapper) : base(repo, mapper)
        {

        }

        public virtual async Task<TInfoDTO> AddEntityAsync(TDto entityDTO)
        {
            if(entityDTO == null)
            {
                throw new ArgumentNullException();
            }
            
            var entity = await _repo.AddAsync(_mapper.Map<TEntity>(entityDTO));
            return await GetEntityInfoAsync(entity.Id);
        }
        public async Task DeleteEntity(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if(entity == null)
            {
                throw new EntityNotFoundException(id);
            }
            await _repo.DeleteAsync(entity);
        }

        public async Task<IEnumerable<TInfoDTO>> GetAllEntitiesAsync()
        {
            var entities = await _repo.ListAsync();
            return _mapper.Map<IEnumerable<TInfoDTO>>(entities);
        }

        public async Task<TDto> GetEntityAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
            {
                throw new EntityNotFoundException(id);
            }

            return _mapper.Map<TDto>(entity);
        }

        public async Task<TInfoDTO> GetEntityInfoAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if(entity == null)
            {
                throw new EntityNotFoundException(id);
            }

            return _mapper.Map<TInfoDTO>(entity);
        }

        public virtual async Task<TInfoDTO> UpdateEntityAsync(int id, TDto entityDTO)
        {
            var entity = _mapper.Map<TEntity>(entityDTO);

            if (entityDTO == null)
            {
                throw new ArgumentNullException();
            }
            if (id != entity.Id)
            {
                throw new ArgumentException($"Id - {id} does not match with entity id - {entity.Id}");
            }
                        
            await _repo.UpdateAsync(entity);
            return await GetEntityInfoAsync(entity.Id);
        }
    }
}
