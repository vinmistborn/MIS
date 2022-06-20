using MIS.Application.DTOs.User;
using System.Collections.Generic;

namespace MIS.Application.DTOs.IdentityResponse
{
    public class AuthorizeResponse<T> where T : UserInfoDTO
    {
        public IEnumerable<string> Errors { get; set; }

        public T User { get; set; }
    }
}
