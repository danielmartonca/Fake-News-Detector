using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, News>
    {
        private readonly INewsRepository _repository;

        public CreateNewsCommandHandler(INewsRepository repository)
        {
            _repository = repository;
        }

        public async Task<News> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var news = new News(request.Title, request.Text, request.Author, request.Date);
            await _repository.AddAsync(news);
            return news;
        }
    }
}
