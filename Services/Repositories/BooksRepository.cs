using Library.Contexts;
using Library.Entities;
using Library.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Library.Services.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly LibraryContext context;

        public BooksRepository(LibraryContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Book?> GetBookAsync(int id)
        {
            return await context.BooksWithAuthorAndPublisher().FirstOrDefaultAsync(book => book.Id == id);
        }

        public async Task<IEnumerable<Book?>> GetBooksAsync()
        {
            return await context.BooksWithAuthorAndPublisher().ToListAsync();
        }

        public async Task<IEnumerable<Book?>> GetBooksByAuthorAsync(string authorName)
        {
            return await context.BooksWithAuthorAndPublisher()
                .Where(book => book.Author != null && book.Author.Name == authorName).ToListAsync();
        }

        public async Task<IEnumerable<Book?>> GetBooksByPublisherAsync(string publisherName)
        {
            return await context.BooksWithAuthorAndPublisher()
                .Where(book => book.Publisher != null && book.Publisher.Name == publisherName).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync() >= 0;
        }
    }
}
