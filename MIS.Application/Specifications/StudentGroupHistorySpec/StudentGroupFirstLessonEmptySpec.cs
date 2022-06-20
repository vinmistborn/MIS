using Ardalis.Specification;
using MIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Application.Specifications.StudentGroupHistorySpec
{
    public class StudentGroupFirstLessonEmptySpec : Specification<StudentGroupHistory>, ISingleResultSpecification
    {
        public StudentGroupFirstLessonEmptySpec()
        {
            Query
                .Include(p => p.Student)
                .Include(p => p.Group)
                .Include(p => p.Course)
                .Where(p => p.FirstLesson == null);
        }
    }
}
