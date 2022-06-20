using AutoMapper;
using MIS.Application.DTOs.Student;
using MIS.Domain.Entities;
using MIS.Application.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace MIS.Application.DTOsResolver
{
    public class StudentGroupCodeResolver : IValueResolver<Student, StudentInfoDTO, IEnumerable<string>>
    {
        public IEnumerable<string> Resolve(Student source, StudentInfoDTO destination, IEnumerable<string> destMember, ResolutionContext context)
        {
            try
            {
                var groupCodes = new List<string>();
                if (source.Groups != null)
                {
                    foreach (var group in source.Groups)
                    {
                        groupCodes.Add(group.Code);
                    }
                }
                return groupCodes;
            }
            catch (Exception ex)
            {
                return new[] { ex.Message };
            }
        }
    }
}
