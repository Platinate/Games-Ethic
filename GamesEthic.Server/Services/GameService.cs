using GamesEthic.Server.Data.Repositories.Interfaces;
using GamesEthic.Server.Models.DTOs.Game;
using GamesEthic.Server.Models.Entities;
using GamesEthic.Server.Models.Generic;
using GamesEthic.Server.Services.Interfaces;
using GamesEthic.Server.Services.Mappings;

namespace GamesEthic.Server.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _repository;
        public GameService(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<GameTO> CreateGame(CreateGameTO createGameTO)
        {
            var game = new Game
            {
                Name = createGameTO.Name,
                ImageUrl = createGameTO.ImageUrl,
            };
            var gameCreated = await _repository.CreateGame(game);
            return gameCreated.ToGameTO();
            
        }

        public async Task<bool> DeleteGame(int id)
        {
            var deleted = await _repository.DeleteGameById(id);
            return deleted;
        }

        public async Task<GameTO?> GetGame(int id)
        {
            var game = await _repository.GetById(id);
            if(game == null) return null;
            return game.ToGameTO();
        }

        public async Task<Page<GameTO>> GetGames(GetGamesQueryTO getGamesQuery)
        {
            var games = await _repository.GetGames(getGamesQuery.Name);
            var page = new Page<GameTO>
            {
                Data = games.Select(g => g.ToGameTO()).Skip((getGamesQuery.Index-1) * getGamesQuery.Size).Take(getGamesQuery.Size).ToList(),
                Index = getGamesQuery.Index,
                Size = getGamesQuery.Size,
                TotalPages = (int)Math.Ceiling((games.Count() / (double)getGamesQuery.Size))
            };
            return page;
        }

        public async Task<GameTO> UpdateGame(int id, UpdateGameTO updateGameTO)
        {
            var game = await _repository.GetById(id);
            game.Name = updateGameTO.Name;
            game.ImageUrl = updateGameTO.ImageUrl;
            await _repository.UpdateGame(game);
            return game.ToGameTO();
        }
    }
}
