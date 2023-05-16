using Library.Entities;

namespace Library.Services.Repositories
{
    public interface IPublishersRepository
    {
        Task<Publisher?> GetPublisherAsync(int? id);
        Task<IEnumerable<Publisher?>> GetPublishersAsync();
        Task<bool> AddPublisherAsync(Publisher publisher);
        Task<bool> AddBookToPublisherAsync(Book book, int authorId);
    }
}
