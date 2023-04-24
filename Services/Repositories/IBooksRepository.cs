using Library.Entities;

namespace Library.Services.Repositories
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book?>> GetBooksAsync();
        Task<IEnumerable<Book?>> GetBooksByAuthorAsync(string authorName);
        Task<IEnumerable<Book?>> GetBooksByPublisherAsync(string publisherName);
        Task<Book?> GetBookAsync(int id);
        Task<bool> SaveChangesAsync();

    }
}
