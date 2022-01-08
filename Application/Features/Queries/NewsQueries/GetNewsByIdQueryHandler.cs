using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries
{
    public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, News>
    {
        private readonly INewsRepository _repository;

        public GetNewsByIdQueryHandler(INewsRepository repository)
        {
            _repository = repository;
        }

        public async Task<News> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Trying to find news by ID");
            var news = await _repository.GetByIdAsync(request.ID);
            Console.WriteLine("Got it: " + news);
            if (news == null)
                throw new Exception("News not found.");
            return news;
        }
    }
}
