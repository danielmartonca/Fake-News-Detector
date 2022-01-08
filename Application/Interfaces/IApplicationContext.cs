using System;
using Domain.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<News> News { get; set; }

        Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

    }
}
