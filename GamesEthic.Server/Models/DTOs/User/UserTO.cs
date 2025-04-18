
namespace GamesEthic.Server.Models.DTOs.User
{
    public sealed class UserTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
    }
}
