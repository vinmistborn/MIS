using AutoMapper;
using MIS.Application.DTOs.Group;
using MIS.Domain.Entities;
using System;
using System.Collections.Generic;


namespace MIS.Application.DTOsResolver
{
    public class GroupTeacherResolver : IValueResolver<Group, GroupFullInfoDTO, IEnumerable<string>>
    {
        public IEnumerable<string> Resolve(Group source, GroupFullInfoDTO destination, IEnumerable<string> destMember, ResolutionContext context)
        {
            try
            {
                var teacherNames = new List<string>();
                if(source.Teachers != null)
                {
                    foreach (var teacher in source.Teachers)
                    {
                        teacherNames.Add($"{teacher.FirstName} {teacher.LastName}");
                    }  
                }
                return teacherNames;
            }
            catch (Exception ex)
            {
                return new[] { ex.Message };
            }
        }
    }
}
