using System;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid ID);
    }
}
