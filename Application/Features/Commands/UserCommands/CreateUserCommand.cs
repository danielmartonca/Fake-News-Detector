using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.UserCommands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
