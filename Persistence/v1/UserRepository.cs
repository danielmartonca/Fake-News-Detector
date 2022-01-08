using Application.Interfaces;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Persistence.v1
{

    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly NewsContext _context;
        public UserRepository(NewsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByUsernameAndPassword(User user)
        {
            if (user == null)
                throw new ArgumentNullException("User object must not be null");

            if (user.Password == null || user.Username == null)
                throw new ArgumentNullException("User object must not have null members.");

            //TODO change this couse it doesn't work
            return await _context.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefaultAsync();
        }
    }
}
