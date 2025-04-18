using GamesEthic.Server.Data.Repositories.Interfaces;
using GamesEthic.Server.Models.DTOs.Game;
using GamesEthic.Server.Models.Entities;
using GamesEthic.Server.Services.Interfaces;

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
            return MapGameToGameTO(gameCreated);
            
        }

        public async Task<GameTO> GetGame(int id)
        {
            var game = await _repository.GetById(id);
            return MapGameToGameTO(game);
        }

        public async Task<IEnumerable<GameTO>> GetGames()
        {
            var games = await _repository.GetGames();
            return games.Select(MapGameToGameTO).ToList();
        }

        public async Task<GameTO> UpdateGame(int id, UpdateGameTO updateGameTO)
        {
            var game = await _repository.GetById(id);
            game.Name = updateGameTO.Name;
            game.ImageUrl = updateGameTO.ImageUrl;
            await _repository.UpdateGame(game);
            return MapGameToGameTO(game);
        }

        private GameTO MapGameToGameTO(Game game)
        {
            return new GameTO
            {
                Id = game.Id,
                Name = game.Name,
                ImageUrl = game.ImageUrl,
            };
        }
    }
}
