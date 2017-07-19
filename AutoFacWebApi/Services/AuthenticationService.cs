namespace AutoFacWebApi.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool Login(string username, string password)
        {
            return username == "tutorial" && password == "tutorial";
        }
    }
}