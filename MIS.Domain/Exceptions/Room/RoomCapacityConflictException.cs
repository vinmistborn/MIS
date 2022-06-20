namespace MIS.Domain.Exceptions.Room
{
    public class RoomCapacityConflictException : BadRequestException
    {
        public RoomCapacityConflictException(int capacity) : base($"Specified Group capacity - {capacity} is more than room capacity")
        {

        }
    }
}
