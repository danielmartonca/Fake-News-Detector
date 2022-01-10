using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Application.Features.Commands.UserCommands;
using Application.Utilities.Accounts;
using Application.Features.Queries.UserQueries;

namespace REST_API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    public class UserController : BaseController
    {
        private readonly ILogger<NewsController> _logger;
        public UserController(ILogger<NewsController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        [HttpPut]
        [Route("create")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            _logger.LogDebug($"PUT\nRegistering user:\nusername:{user.Username}\nEmail:{user.Email}");

            if (AccountsUtil.ValidateUserCredentials(user) == false)
                return BadRequest("Invalid user data.");
            _logger.LogDebug("Attempting to create user.");

            var result = await Mediator.Send(new CreateUserCommand { Username = user.Username, Password = user.Password, Email = user.Email });

            if (result != null)
            {
                _logger.LogDebug($"Created user with credentials {result}");
                return Created("NOT IMPLEMENTED", result);
            }

            return BadRequest("Failed to create user. Check user data again");
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            _logger.LogDebug($"POST\nLogin attempt:\nusername:{user.Username}\npassword:{user.Password}");

            user.Email = " ";
            if (AccountsUtil.ValidateUserCredentials(user) == false)
                return BadRequest("Invalid user data.");

            _logger.LogDebug("Attempting to login.");

            var account = await Mediator.Send(new GetUserByUsernameAndPasswordQuery(user));

            if (account != null)
            {
                _logger.LogDebug($"Credentials {account} were ok for user. Logging in.");

                _logger.LogDebug($"Creating sessionId for user {account.Username}.");
                var sessionId = await Mediator.Send(new CreateSessionIdQuery(account.Username));

                return Ok(sessionId);
            }

            return Unauthorized("Invalid credentials");
        }

        [HttpPost]
        [Route("sessionID")]
        public async Task<IActionResult> SessionID([FromBody] UserSession userSession)
        {
            _logger.LogDebug($"POST\nSessionID check attempt:\nusername:{userSession.Username}\nsessionID:{userSession.SessionId}\n");

            _logger.LogDebug($"Attempting to check SessionID '{userSession.SessionId}' for user {userSession.Username}");

            var UserSession = await Mediator.Send(new GetUserSessionBySessionIdAndUsernameQuery(userSession));
            if (UserSession != null)
                return Ok();

            return Unauthorized("Invalid session id");
        }
        [HttpDelete]
        [Route("sessionID")]
        public async Task<IActionResult> DeleteSessionID([FromBody] UserSession userSession)
        {
            _logger.LogDebug($"POST\nSessionID delete :\nusername:{userSession.Username}\nsessionID:{userSession.SessionId}\n");

            _logger.LogDebug($"Deleting SessionID '{userSession.SessionId}' for user {userSession.Username}");

            var result = await Mediator.Send(new DeleteSessionIdQuery(userSession));
            if (result == null)
                return BadRequest("Invalid user session sent");

            return Ok();

        }
    }
}
