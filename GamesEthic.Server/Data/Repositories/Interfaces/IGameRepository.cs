using GamesEthic.Server.Models.Entities;

namespace GamesEthic.Server.Data.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetGames();
        Task<Game> GetById(int id);
        
        Task<Game> CreateGame(Game game);
        Task<Game> UpdateGame(Game game);
        Task<bool> DeleteGameById(int id);
    }
}
