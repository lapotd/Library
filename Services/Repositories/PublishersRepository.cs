using Library.Entities;
using Library.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Library.Services.Repositories
{
    public class PublishersRepository : IPublishersRepository
    {
        private readonly IDatabaseService database;

        public PublishersRepository(IDatabaseService database)
        {
            this.database = database;
        }

        public async Task<Publisher?> GetPublisherAsync(int? id)
        {
            return await this.database.PublishersWithBooks().FirstOrDefaultAsync(publisher => publisher.Id == id);
        }

        public async Task<IEnumerable<Publisher?>> GetPublishersAsync()
        {
            return await this.database.PublishersWithBooks().ToListAsync();
        }

        public async Task<bool> AddBookToPublisherAsync(Book book, int publisherId)
        {
            var publisher = await GetPublisherAsync(publisherId);
            if (publisher != null)
            {
                publisher.Books?.Add(book);
            }
            return await this.SaveChangesAsync();
        }

        public async Task<bool> AddPublisherAsync(Publisher publisher)
        {
            await this.database.AddEntityAsync(publisher);
            return await this.SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await this.database.SaveAsync();
        }
    }
}
