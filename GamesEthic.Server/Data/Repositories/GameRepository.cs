using GamesEthic.Server.Data.Repositories.Interfaces;
using GamesEthic.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesEthic.Server.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GamesEthicDbContext _dbContext;
        public GameRepository(GamesEthicDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Game> CreateGame(Game game)
        {
            _dbContext.Games.Add(game);
            await _dbContext.SaveChangesAsync();
            return game;
        }

        public async Task<bool> DeleteGameById(int id)
        {
            var game = _dbContext.Games.FirstOrDefault(x => x.Id == id);
            if (game == null) return false;
            _dbContext.Games.Remove(game);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Game>> GetGames()
        {
            var games = await _dbContext.Games.ToListAsync();
            return games;
        }

        public async Task<Game> GetById(int id)
        {
            var game = await _dbContext.Games.FirstOrDefaultAsync(x => x.Id == id);
            return game;
        }

        public async Task<Game> UpdateGame(Game game)
        {
            _dbContext.Games.Update(game);
            await _dbContext.SaveChangesAsync();
            return game;
        }
    }
}
