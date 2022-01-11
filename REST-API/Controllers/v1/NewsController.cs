using System;
using System.Threading.Tasks;
using Application.Features.Commands;
using Application.Features.Queries;
using Application.Utilities.Scrapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace REST_API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    public class NewsController : BaseController
    {
        private readonly ILogger<NewsController> _logger;

        public NewsController(ILogger<NewsController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery(Name = "id")] Guid id)
        {
            _logger.LogDebug($"Get id:{id}");
            var result = await Mediator.Send(new GetNewsByIdQuery(id));
            _logger.LogDebug($"Found this data: {result}.");

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] News news)
        {
            _logger.LogDebug($"PUT \nID: {news.Id}\ntitle: {news.Title}\ntext: {news.Text}\nauthor: {news.Author}\n");
            _logger.LogDebug("Adding entry to news database.");
            var result = await Mediator.Send(new CreateUserCommand(news));

            if (result != null)
            {
                _logger.LogDebug($"Created news: {result} succesfully.");
                return Created("NOT IMPLEMENTED", result);
            }

            return BadRequest("Failed to create news. Check news data again");
        }

        [HttpPost]
        public async Task<IActionResult> PostNewsAsync([FromBody] News news)
        {
            _logger.LogDebug($"POST \nID: {news.Id}\ntitle: {news.Title}\ntext: {news.Text}\nauthor: {news.Author}\n");
            _logger.LogDebug("Calling machine learning algorithm to predict news.");
            var result = await Mediator.Send(new PredictQuery(news));
            _logger.LogDebug($"Predicted: {result}");

            return Ok(result);
        }


        [HttpPost]
        [Route("link")]
        public async Task<IActionResult> PostNewsLinkAsync([FromBody] UrlLink link)
        {
            _logger.LogDebug($"POST link\nurl: {link.InputUrl}\n");
            _logger.LogDebug("Calling scrapper algorithm to get news.");
            var news = WebScrapper.GetNewsFromUrl(link.InputUrl);
            if (news == null)
                return BadRequest("URL does not contain any news.");
            _logger.LogDebug("Calling machine learning algorithm to predict news.");
            var result = await Mediator.Send(new PredictQuery(news));
            if (result == null)
                return BadRequest("Machine learining algorithm failed.");
            _logger.LogDebug($"Predicted: {result}");

            return Ok(result);
        }
    }
}
