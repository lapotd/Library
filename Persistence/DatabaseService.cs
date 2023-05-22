using Library.Entities;
using Microsoft.EntityFrameworkCore;
namespace Persistence
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Publisher> Publishers { get; set; } = null!;

        public DatabaseService(DbContextOptions<DatabaseService> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasMany(author => author.Books)
                .WithOne(book => book.Author)
                .HasForeignKey(book => book.AuthorId);
            modelBuilder.Entity<Publisher>().HasMany(publisher => publisher.Books)
                .WithOne(book => book.Publisher)
                .HasForeignKey(book => book.PublisherId); ;
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> SaveAsync()
        {
            return await this.SaveChangesAsync() > 0;
        }

        public async Task AddEntityAsync<T>(T entity)
        {
            if (entity is not null)
            {
                await this.AddAsync(entity);
            }

        }


    }
}