using Library.Entities;

namespace Library.Services.Repositories
{
    public interface IPublishersRepository
    {
        Task<Publisher?> GetPublisherAsync(int? id);
        Task<IEnumerable<Publisher?>> GetPublishersAsync();
        Task AddPublisherAsync(Publisher publisher);
        Task AddBookToPublisherAsync(Book book, int authorId);
        Task<bool> SaveChangesAsync();
    }
}
