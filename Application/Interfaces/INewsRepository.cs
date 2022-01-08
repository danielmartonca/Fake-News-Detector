using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INewsRepository : IRepository<News>
    {
        public Task<News> GetByTitleAsync(string title);

        public Task<News> GetByGenreAsync(string genre);

        public Task<News> GetByDateAsync(DateTime date);
    }
}
