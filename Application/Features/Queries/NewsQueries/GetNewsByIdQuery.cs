using System;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries
{
    public class GetNewsByIdQuery : IRequest<News>
    {
        public Guid ID { get; set; }
        public GetNewsByIdQuery(Guid id)
        {
            ID = id;
        }
    }
}
