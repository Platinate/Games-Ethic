using GamesEthic.Server.Models.DTOs.User;
using GamesEthic.Server.Models.Entities;

namespace GamesEthic.Server.Services.Mappings
{
    public static class UserMapping
    {
        public static UserTO ToUserTO(this User user)
        {
            return new UserTO
            {
                Username = user.UserName,
                Email = user.Email,
            };
        }

        public static UserTO ToUserTO(this User user, IList<string> roles)
        {
            return new UserTO
            {
                Username = user.UserName,
                Email = user.Email,
                Roles = roles
            };
        }
    }
}
