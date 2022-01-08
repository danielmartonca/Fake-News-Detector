using Domain.Entities;
using MediatR;
using System;

namespace Application.Features.Commands
{
    public class PredictQuery : IRequest<string>
    {
        public String Title { get; set; }
        public String Author { get; set; }
        public String Text { get; set; }

        public PredictQuery(News news)
        {
            Title = news.Title;
            Author = news.Author;
            Text = news.Text;
        }
    }
}
