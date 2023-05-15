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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasMany(author => author.Books)
                .WithOne(book => book.Author)
                .HasForeignKey(book=> book.AuthorId);
            modelBuilder.Entity<Publisher>().HasMany(publisher => publisher.Books)
                .WithOne(book => book.Publisher)
                .HasForeignKey(book => book.PublisherId); ;
            base.OnModelCreating(modelBuilder);
        }
    }

}
