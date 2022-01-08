using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Utilities.Accounts;

namespace Application.Features.Commands.UserCommands
{
    public class CreateSessionIdQueryHandler : IRequestHandler<CreateSessionIdQuery, UserSession>
    {
        private readonly ISessionRepository _repository;

        public CreateSessionIdQueryHandler(ISessionRepository repository)
        {
            _repository = repository;
        }
        public async Task<UserSession> Handle(CreateSessionIdQuery request, CancellationToken cancellationToken)
        {
            var session = new UserSession { Username = request.Username, SessionId = AccountsUtil.GenerateSessionId() };

            while (await _repository.GetBySessionId(session.SessionId) != null)
                session.SessionId = AccountsUtil.GenerateSessionId();

            var result = await _repository.AddAsync(session);
            return result;
        }
    }
}
