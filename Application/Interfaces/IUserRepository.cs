using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetByUsernameAndPassword(User user);
    }
}
