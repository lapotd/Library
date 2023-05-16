using Library.Entities;
using Library.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Library.Services.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly IDatabaseService database;

        public AuthorsRepository(IDatabaseService database)
        {
            this.database = database;

        }

        public async Task<Author?> GetAuthorAsync(int? id)
        {
            return await this.database.AuthorsWithBooks().FirstOrDefaultAsync(author => author.Id == id);
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await this.database.AuthorsWithBooks().ToListAsync();
        }

        public async Task<bool> AddBookToAuthorAsync(Book book, int authorId)
        {
            var author = await GetAuthorAsync(authorId);
            if (author != null)
            {
                author.Books?.Add(book);
            }
            return await SaveChangesAsync();
            
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await this.database.SaveAsync();
        }

        public async Task<bool> AddAuthorAsync(Author author)
        {
            await this.database.AddEntityAsync(author);
            return await SaveChangesAsync();
        }


    }
}
