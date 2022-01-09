using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.UserCommands
{
    public class DeleteSessionIdQuery
    {

        public UserSession userSession { get; set; }
        public DeleteSessionIdQuery(UserSession session)
        {
            userSession = session;
        }

    }
}
