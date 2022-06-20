using AutoMapper;
using MIS.Application.DTOs.Timetable;
using MIS.Application.Interfaces.Services;
using MIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Application.DTOsResolver
{
    public class TimetableGroupCodeResolver : IValueResolver<Timetable, TimetableInfoDTO, string>
    {
        public string Resolve(Timetable source, TimetableInfoDTO destination,
                              string destMember, ResolutionContext context)
        {
            try
            {
                string groupCode = "not assigned";
                if (source.Group != null)
                {
                    groupCode = source.Group.Code;
                }
                return groupCode;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
