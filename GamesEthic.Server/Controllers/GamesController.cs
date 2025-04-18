using GamesEthic.Server.Models.DTOs.Game;
using GamesEthic.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamesEthic.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _service;
        public GamesController(IGameService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetGames")]
        public async Task<ActionResult<IEnumerable<GameTO>>> Get()
        {
            var games = await _service.GetGames();
            return Ok(games);
        }

        [HttpGet(Name = "GetGame")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id:int}")]
        public async Task<ActionResult<GameTO>> Get(int id)
        {
            var game = await _service.GetGame(id);
            if(game == null) return NotFound();
            return Ok(game);
        }

        [HttpPost(Name = "CreateGame")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GameTO>> CreateGame([FromBody] CreateGameTO createGameTO)
        {
            var game = await _service.CreateGame(createGameTO);
            return CreatedAtRoute("GetGame",new { id = game.Id});
        }
    }
}
