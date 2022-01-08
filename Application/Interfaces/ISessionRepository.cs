using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISessionRepository : IRepository<UserSession>
    {
        public Task<UserSession> GetByUsername(string username);
        public Task<UserSession> GetBySessionId(Guid sessionId);
    }
}
