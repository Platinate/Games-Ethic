using GamesEthic.Server.Models.DTOs.Game;
using GamesEthic.Server.Models.Generic;

namespace GamesEthic.Server.Services.Interfaces
{
    public interface IGameService
    {
        Task<Page<GameTO>> GetGames(GetGamesQueryTO getGamesQueryTO);
        Task<GameTO> GetGame(int id);
        Task<GameTO> CreateGame(CreateGameTO createGameTO);
        Task<GameTO> UpdateGame(int id, UpdateGameTO updateGameTO);
        Task<bool> DeleteGame(int id);
    }
}
