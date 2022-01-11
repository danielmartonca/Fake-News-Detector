using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Common;
using Persistence.Context;

namespace Persistence.v1
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly NewsContext _context;

        public Repository(NewsContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> GetByIdAsync(Guid ID)
        {
            if (ID == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(GetByIdAsync)} id must not be empty");
            }

            return await _context.FindAsync<TEntity>(ID);
        }
    }
}
