using Library.Entities;
using Library.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Library.Services.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly IDatabaseService database;

        public BooksRepository(IDatabaseService database)
        {
            this.database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public async Task<Book?> GetBookAsync(int bookId)
        {
            return await database.BooksWithAuthorAndPublisher().FirstOrDefaultAsync(book => book.Id == bookId);
        }

        public async Task<IEnumerable<Book?>> GetBooksAsync()
        {
            return await database.BooksWithAuthorAndPublisher().ToListAsync();
        }

        public async Task<IEnumerable<Book?>> GetBooksByAuthorAsync(string authorName)
        {
            return await database.BooksWithAuthorAndPublisher()
                .Where(book => book.Author != null && book.Author.Name == authorName).ToListAsync();
        }

        public async Task<IEnumerable<Book?>> GetBooksByPublisherAsync(string publisherName)
        {
            return await database.BooksWithAuthorAndPublisher()
                .Where(book => book.Publisher != null && book.Publisher.Name == publisherName).ToListAsync();
        }

        public async Task<bool> AddBookAsync(Book book)
        {
           await this.database.AddEntityAsync(book);
            return await this.SaveChangesAsync();
        }

        public async Task<bool> AddAuthorToBookAsync(int bookId, Author author)
        {
            var book = await GetBookAsync(bookId);
            if(book != null)
            {
                book.Author = author;
            }
            return await SaveChangesAsync();


        }

        public async Task<bool> AddPublisherToBookAsync(int bookId, Publisher publisher)
        {
            var book = await GetBookAsync(bookId);
            if (book != null)
            {
                book.Publisher = publisher;
            }
            return await this.SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await this.database.SaveAsync();
        }
    }
}
