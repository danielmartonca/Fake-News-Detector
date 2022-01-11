using System;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands
{
    public class CreateUserCommand : IRequest<News>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }

        public CreateUserCommand(News news)
        {
            Title = news.Title;
            Text = news.Text;
            Date = news.Date;
            Author = news.Author;
        }
    }
}
