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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public async Task<Game> CreateGame(Game game)
        {
            _dbContext.Games.Add(game);
            await _dbContext.SaveChangesAsync();
            return game;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteGameById(int id)
        {
            var game = await _dbContext.Games.FindAsync(id);
            if (game is null) return false;

            _dbContext.Games.Remove(game);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Game>> GetGames(string name)
        {
            return await _dbContext.Games
                .Where(x => string.IsNullOrEmpty(name) || x.Name == name)
                .ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Game?> GetById(int id)
        {
            return await _dbContext.Games.FindAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public async Task<Game> UpdateGame(Game game)
        {
            _dbContext.Games.Update(game);
            await _dbContext.SaveChangesAsync();
            return game;
        }
    }
}
