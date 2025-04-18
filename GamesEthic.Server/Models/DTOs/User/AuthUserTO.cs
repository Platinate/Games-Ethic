
namespace GamesEthic.Server.Models.DTOs.User
{
    public class AuthUserTO
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public IList<string> Roles { get; set; }
    }
}
