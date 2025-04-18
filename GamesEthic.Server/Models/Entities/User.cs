using Microsoft.AspNetCore.Identity;

namespace GamesEthic.Server.Models.Entities
{
    public sealed class User : IdentityUser
    {
        public string? DisplayName { get; set; }
    }
}
