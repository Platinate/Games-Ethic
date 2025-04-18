using GamesEthic.Server.Models.DTOs.Game;
using GamesEthic.Server.Models.Generic;
using GamesEthic.Server.Services.Interfaces;
using GamesEthic.Server.Services.Mappings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GamesEthic.Server.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public GamesController(IGameService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getGamesQueryTO"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetGames")]
        public async Task<ActionResult<Page<GameTO>>> Get([FromQuery] GetGamesQueryTO getGamesQueryTO)
        {
            var games = await _service.GetGames(getGamesQueryTO);
            return Ok(games);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetGame")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GameTO>> Get(int id)
        {
            var game = await _service.GetGame(id);
            if (game == null) return NotFound();
            return Ok(game);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createGameTO"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateGame")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GameTO>> CreateGame([FromBody] CreateGameTO createGameTO)
        {
            var game = await _service.CreateGame(createGameTO);
            return CreatedAtAction(nameof(Get), new { id = game.Id }, game);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateGameTO"></param>
        /// <returns></returns>
        [HttpPut("{id:int}", Name = "UpdateGame")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GameTO>> UpdateGame(int id, [FromBody] UpdateGameTO updateGameTO)
        {
            var game = await _service.UpdateGame(id, updateGameTO);
            return Ok(game);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}", Name = "DeleteGame")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteGame(int id)
        {
            var deleted = await _service.DeleteGame(id);
            if (deleted)
                return Ok();
            return BadRequest();
        }

        [HttpPatch("{id:int}", Name = "PatchGame")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GameTO>> PatchGame(int id, [FromBody] JsonPatchDocument<UpdateGameTO> patchDoc)
        {
            if (patchDoc is null) return BadRequest();

            var game = await _service.GetGame(id);
            if (game is null) return NotFound();

            var toUpdate = game.ToUpdateGameTO();

            patchDoc.ApplyTo(toUpdate);

            var updatedGame = await _service.UpdateGame(id, toUpdate);

            return Ok(updatedGame);
        }
    }
}
