using MIS.Application.DTOs.Room;
using MIS.Domain.Entities;
using MIS.Shared.Interfaces.Services;

namespace MIS.Application.Interfaces.Services
{
    public interface IRoomService : IGenericService<Room, RoomDTO, RoomInfoDTO>
    {

    }
}
