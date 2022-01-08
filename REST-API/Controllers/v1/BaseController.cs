using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace REST_API.Controllers.v1
{
    [Route("api/{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator Mediator;

        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
