using Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Contexts
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Publisher> Publishers { get; set; } = null!;

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options) { }

    }

}
