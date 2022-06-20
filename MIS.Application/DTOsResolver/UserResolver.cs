using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace MIS.Application.DTOsResolver
{
    public class GenericUserResolver<TSource, TDestination, TDestMember> 
                    : IValueResolver<TSource, TDestination, IEnumerable<string>> where TSource : class
                                                                                 where TDestination : class                                                                         
                                                                               
    {
        private readonly UserManager<TSource> _userManager;

        public GenericUserResolver(UserManager<TSource> userManager)
        {
            _userManager = userManager;
        }

        public IEnumerable<string> Resolve(TSource source,
                                           TDestination destination,
                                           IEnumerable<string> destMember,
                                           ResolutionContext context)
        {
            try
            {
                var role = _userManager.GetRolesAsync(source).Result;
                return role;
            }
            catch (Exception ex)
            {
                return new[] { ex.Message };
            }
        }
    }
}
