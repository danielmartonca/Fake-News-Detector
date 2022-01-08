using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Utilities;

namespace Application.Features.Queries.UserQueries
{
    public class GetUserByUsernameAndPasswordQueryHandler : IRequestHandler<GetUserByUsernameAndPasswordQuery, User>
    {
        private readonly IUserRepository _repository;

        public GetUserByUsernameAndPasswordQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }


        public async Task<User> Handle(GetUserByUsernameAndPasswordQuery request, CancellationToken cancellationToken)
        {
            string hashedPassword = HashingUtil.GetHash(request.Password);
            var user = new User { Username = request.Username, Password = hashedPassword };

            var result = await _repository.GetByUsernameAndPassword(user);

            return result;
        }
    }
}
