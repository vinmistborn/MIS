using MIS.Application.DTOs.Student;
using MIS.Application.DTOs.StudentGroupHistory;
using MIS.Domain.Entities;
using System.Collections.Generic;
using MIS.Shared.Interfaces.Services;
using System.Threading.Tasks;

namespace MIS.Application.Interfaces.Services
{
   public interface IStudentService : IGenericServiceInfoSpec<Student, StudentInfoDTO>
    {
        Task<StudentInfoDTO> AddStudentAsync(StudentDTO studentDTO);
        Task<StudentInfoDTO> UpdateStudentAsync(int id, StudentDTO studentDTO);
        Task<StudentInfoDTO> AddGroupsToStudentAsync(int studentId, NewStudentGroups groups);
        Task<StudentInfoDTO> RemoveGroupFromStudent(int studentId, RemoveGroupDTO group);
        Task<IEnumerable<StudentGroupHistoryDTO>> GetStudentGroupsListAsync(int id);
        Task<StudentInfoDTO> ArchiveStudentAsync(int id);
        Task<StudentDTO> GetStudentForUpdate(int id);
    }
}
