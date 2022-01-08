using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.UserQueries
{
    public class GetUserByUsernameAndPasswordQuery : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public GetUserByUsernameAndPasswordQuery(User user)
        {
            Username = user.Username;
            Password = user.Password;
        }
    }
}
