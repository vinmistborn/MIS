using AutoMapper;
using MIS.Application.DTOs.Room;
using MIS.Domain.Entities;
using MIS.Application.Interfaces.Services;
using MIS.Application.Specifications;
using MIS.Shared.Interfaces;
using System;
using System.Threading.Tasks;

namespace MIS.Application.Services
{
    public class RoomService : GenericService<Room, RoomDTO, RoomInfoDTO> ,IRoomService
    {
        
        public RoomService(IRepository<Room> repo,
                           IMapper mapper) : base(repo, mapper)
        {

        }

        public override async Task<RoomInfoDTO> AddEntityAsync(RoomDTO roomDTO)
        {
            if (roomDTO == null)
            {
                throw new ArgumentNullException();
            }

            var room = await _repo.AddAsync(_mapper.Map<Room>(roomDTO));
            return await GetEntityInfoSpecAsync(new RoomWithBranchSpec(room.Id));
        }

        public override async Task<RoomInfoDTO> UpdateEntityAsync(int id, RoomDTO roomDTO)
        {
            if (roomDTO == null)
            {
                throw new ArgumentNullException();
            }
            if (id != roomDTO.Id)
            {
                throw new ArgumentException($"Id - {id} does not match with room id - {roomDTO.Id}");
            }

            var room = _mapper.Map<Room>(roomDTO);
            await _repo.UpdateAsync(room);            
            return await GetEntityInfoSpecAsync(new RoomWithBranchSpec(room.Id));
        }
    }
}
