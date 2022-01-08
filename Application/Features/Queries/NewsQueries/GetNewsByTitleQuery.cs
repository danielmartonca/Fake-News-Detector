using System;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries
{
    public class GetNewsByTitleQuery : IRequest<News>

    {
        public String Title { get; set; }
    }
}
