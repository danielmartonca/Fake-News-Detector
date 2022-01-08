using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.UserCommands
{
    public class CreateSessionIdQuery : IRequest<UserSession>
    {

        public string Username { get; set; }
        public CreateSessionIdQuery(string username)
        {
            Username = username;
        }

    }
}
