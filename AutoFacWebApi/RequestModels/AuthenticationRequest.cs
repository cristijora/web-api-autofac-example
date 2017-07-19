using System.ComponentModel.DataAnnotations;

namespace AutoFacWebApi.RequestModels
{
    public class AuthenticationRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}