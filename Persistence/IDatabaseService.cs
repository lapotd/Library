using Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public interface IDatabaseService
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Publisher> Publishers { get; set; }
        DbSet<Book> Books { get; set; }

        Task<bool> SaveAsync();
        Task AddEntityAsync<T>(T entity);
    }
}
