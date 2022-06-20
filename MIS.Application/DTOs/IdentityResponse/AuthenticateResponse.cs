namespace MIS.Application.DTOs.IdentityResponse
{
    public class AuthenticateResponse  
    {
        public bool Successful { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
    }
}
