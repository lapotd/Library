using Library.Contexts;
using Library.Entities;
using Library.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Library.Services.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly LibraryContext context;

        public AuthorsRepository(LibraryContext context)
        {
            this.context = context;

        }

        public Task<bool> AddBookToAuthor(Book book, int authorId)
        {
            throw new NotImplementedException();
        }

        public async Task<Author?> GetAuthor(int id)
        {
            return await this.context.AuthorsWithBooks().FirstOrDefaultAsync(author => author.Id == id);
        }

        public async Task<IEnumerable<Author?>> GetAuthors()
        {
            return await this.context.AuthorsWithBooks().ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync() >= 0;
        }
    }
}
