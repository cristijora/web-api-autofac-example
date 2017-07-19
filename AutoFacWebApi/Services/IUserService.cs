using AutoFacWebApi.Models;

namespace AutoFacWebApi.Services
{
    public interface IUserService
    {
        User GetUser(string username, string password);
    }
}