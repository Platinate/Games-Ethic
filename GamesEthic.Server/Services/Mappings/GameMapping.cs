using GamesEthic.Server.Models.DTOs.Game;
using GamesEthic.Server.Models.Entities;

namespace GamesEthic.Server.Services.Mappings
{
    /// <summary>
    /// 
    /// </summary>
    public static class GameMapping
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public static GameTO ToGameTO(this Game game)
        {
            return new GameTO
            {
                Id = game.Id,
                Name = game.Name,
                ImageUrl = game.ImageUrl,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public static UpdateGameTO ToUpdateGameTO(this GameTO game)
        {
            return new UpdateGameTO
            {
                Name = game.Name,
                ImageUrl = game.ImageUrl,
            };
        }

    }
}
