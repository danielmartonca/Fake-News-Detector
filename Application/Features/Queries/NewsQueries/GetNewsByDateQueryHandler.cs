using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries
{
    public class GetNewsByDateQueryHandler : IRequestHandler<GetNewsByDateQuery, News>
    {
        private readonly INewsRepository _repository;

        public GetNewsByDateQueryHandler(INewsRepository repository)
        {
            _repository = repository;
        }

        public Task<News> Handle(GetNewsByDateQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetByDateAsync(request.Date);
        }
    }
}
