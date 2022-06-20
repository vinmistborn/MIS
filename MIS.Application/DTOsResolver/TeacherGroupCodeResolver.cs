using AutoMapper;
using MIS.Application.DTOs.Teacher;
using MIS.Domain.Entities;
using MIS.Application.Helpers;
using MIS.Application.Specifications.GroupSpec;
using MIS.Shared.Interfaces;
using System;
using System.Collections.Generic;
using MIS.Application.Interfaces.Services;

namespace MIS.Application.DTOsResolver
{
    public class TeacherGroupCodeResolver : IValueResolver<Teacher, TeacherInfoDTO, IEnumerable<string>>
    {
        public IEnumerable<string> Resolve(Teacher source, TeacherInfoDTO destination, IEnumerable<string> destMember, ResolutionContext context)
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
