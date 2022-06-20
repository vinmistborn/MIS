using Microsoft.AspNetCore.Http;
using MIS.Application.Interfaces.Services;
using System;

namespace MIS.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserName()
        {
            return _httpContextAccessor.HttpContext.User.Identity.Name;
        }
    }
}
