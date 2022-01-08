using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Utilities;
using System;

namespace Application.Features.Queries.UserQueries
{
    class GetUserSessionBySessionIdAndUsernameQueryHandler : IRequestHandler<GetUserSessionBySessionIdAndUsernameQuery, UserSession>
    {
        private readonly ISessionRepository _repository;

        public GetUserSessionBySessionIdAndUsernameQueryHandler(ISessionRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserSession> Handle(GetUserSessionBySessionIdAndUsernameQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetBySessionId(request.SessionId);
            if (result == null) return null;
            if (result.Username != request.Username) return null;


            return result;
        }
    }
}
