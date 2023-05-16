using Library.Entities;

namespace Library.Services.Repositories
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book?>> GetBooksAsync();
        Task<IEnumerable<Book?>> GetBooksByAuthorAsync(string authorName);
        Task<IEnumerable<Book?>> GetBooksByPublisherAsync(string publisherName);
        Task<Book?> GetBookAsync(int bookId);
        Task<bool> AddBookAsync(Book book);
        Task<bool> AddPublisherToBookAsync(int bookId, Publisher publisher);
        Task<bool> AddAuthorToBookAsync(int bookId, Author author);


    }
}
