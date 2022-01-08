using System;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.UserQueries
{
    public class GetUserSessionBySessionIdAndUsernameQuery : IRequest<UserSession>
    {
        public string Username { get; set; }
        public Guid SessionId { get; set; }

        public GetUserSessionBySessionIdAndUsernameQuery(UserSession userSession)
        {
            Username = userSession.Username;
            SessionId = userSession.SessionId;
        }
    }
}

