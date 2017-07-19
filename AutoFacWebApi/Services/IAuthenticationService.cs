namespace AutoFacWebApi.Services
{
    public interface IAuthenticationService
    {
        bool Login(string username, string password);
    }
}