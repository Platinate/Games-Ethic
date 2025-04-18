using GamesEthic.Server.Models.DTOs.User;
using GamesEthic.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UsersEthic.Server.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserTO>> GetUser()
        {
            if (!HttpContext.User.Identity?.IsAuthenticated ?? false)
                return Unauthorized("Token absent ou non valide");

            var user = HttpContext.User;

            var email = user.FindFirst(ClaimTypes.Email)?.Value;
            var userTO = await _service.GetUser(email);
            return Ok(userTO);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginUserTO"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login", Name = "Login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthUserTO>> CreateUser([FromBody] LoginUserTO loginUserTO)
        {
            var user = await _service.Login(loginUserTO);
            return Ok(user);
        }
    }
}
