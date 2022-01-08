using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Utilities;

namespace Application.Features.Commands.UserCommands
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            string hashedPassword = HashingUtil.GetHash(request.Password);
            var user = new User { Username = request.Username, Password = hashedPassword, Email = request.Email };
            await _repository.AddAsync(user);
         
            return user;
        }
    }
}
