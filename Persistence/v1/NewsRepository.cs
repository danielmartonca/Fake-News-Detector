using Application.Interfaces;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Threading.Tasks;

namespace Persistence.v1
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        private readonly NewsContext _context;

        public NewsRepository(NewsContext context) : base(context)
        {
            _context = context;
        }
        public async Task<News> GetByTitleAsync(string title)
        {
            if (title == null)
            {
                throw new ArgumentException($"{nameof(GetByTitleAsync)} title must not be empty");
            }

            return await _context.News.FindAsync(title);
        }

        public async Task<News> GetByGenreAsync(string genre)
        {
            if (genre == null)
            {
                throw new ArgumentException($"{nameof(GetByGenreAsync)} genre must not be empty");
            }
            return await _context.News.FindAsync(genre);
        }

        public async Task<News> GetByDateAsync(DateTime date)
        {
            return await _context.News.FindAsync(date);
        }
    }
}
