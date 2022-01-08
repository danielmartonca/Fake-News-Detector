using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries
{
    public class GetNewsByTitleQueryHandler : IRequestHandler<GetNewsByTitleQuery, News>
    {
        private readonly INewsRepository _repository;

        public GetNewsByTitleQueryHandler(INewsRepository repository)
        {
            _repository = repository;
        }

        public Task<News> Handle(GetNewsByTitleQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetByTitleAsync(request.Title);
        }
    }
}
