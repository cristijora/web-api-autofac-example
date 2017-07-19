using AutoFacWebApi.Models;

namespace AutoFacWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IAuthenticationService _authenticationService;

        public UserService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public User GetUser(string username, string password)
        {
            if (!_authenticationService.Login(username, password)) return null;

            return new User
            {
                Email = $"{username}@gmail.com",
                UserName = username,
                FirstName = "First",
                LastName = "Last"
            };
        }
    }
}