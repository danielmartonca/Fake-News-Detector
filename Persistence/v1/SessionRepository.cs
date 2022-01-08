using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.v1
{
    public class SessionRepository : Repository<UserSession>, ISessionRepository
    {
        private readonly NewsContext _context;

        public SessionRepository(NewsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserSession> GetBySessionId(Guid sessionId)
        {
            if (sessionId == Guid.Empty)
               throw new ArgumentNullException($"sessionId {nameof(sessionId)} cannot be null");
            return await _context.UserSessions.Where(u => u.SessionId == sessionId).FirstOrDefaultAsync();
        }

        public async Task<UserSession> GetByUsername(string username)
        {
            if (username == string.Empty)
                throw new ArgumentNullException($"username {nameof(username)} cannot be null");
            return await _context.UserSessions.Where(u => u.Username == username).FirstOrDefaultAsync();
        }
    }
}
