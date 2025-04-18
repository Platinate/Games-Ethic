using GamesEthic.Server.Models.DTOs.Game;

namespace GamesEthic.Server.Services.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameTO>> GetGames();
        Task<GameTO> GetGame(int id);
        Task<GameTO> CreateGame(CreateGameTO createGameTO);
        Task<GameTO> UpdateGame(int id, UpdateGameTO updateGameTO);
    }
}
