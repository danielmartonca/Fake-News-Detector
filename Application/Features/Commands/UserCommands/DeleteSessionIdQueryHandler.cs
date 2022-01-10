using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Utilities.Accounts;

namespace Application.Features.Commands.UserCommands
{
    public class DeleteSessionIdQueryHandler: IRequestHandler<DeleteSessionIdQuery, UserSession>
    {
        private readonly ISessionRepository _repository;

        public DeleteSessionIdQueryHandler(ISessionRepository repository)
        {
            _repository = repository;
        }
        public async Task<UserSession> Handle(DeleteSessionIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteByUserSession(request.userSession);
        }

    }
}
