using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.UserCommands
{
    public class DeleteSessionIdQuery : IRequest<UserSession>
    {

        public UserSession userSession { get; set; }
        public DeleteSessionIdQuery(UserSession session)
        {
            userSession = session;
        }

    }
}
