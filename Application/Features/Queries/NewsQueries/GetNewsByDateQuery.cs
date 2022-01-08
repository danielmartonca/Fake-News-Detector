using System;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries
{
    public class GetNewsByDateQuery : IRequest<News>
    {
        public DateTime Date { get; set; }
    }
}
