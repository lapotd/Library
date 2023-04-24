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

        public async Task<Author?> GetAuthorAsync(int? id)
        {
            return await this.context.AuthorsWithBooks().FirstOrDefaultAsync(author => author.Id == id);
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await this.context.Authors.ToListAsync();
        }

        public async Task AddBookToAuthorAsync(Book book, int authorId)
        {
            var author = await GetAuthorAsync(authorId);
            if (author != null)
            {
                author.Books?.Add(book);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync() >= 0;
        }

        public async Task AddAuthorAsync(Author author)
        {
            await this.context.AddAsync(author);
        }


    }
}
