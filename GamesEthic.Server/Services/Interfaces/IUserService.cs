using GamesEthic.Server.Models.DTOs.User;

namespace GamesEthic.Server.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserTO> GetUser(string? email);
        Task<AuthUserTO> Login(LoginUserTO loginUserTO);
    }
}
