using Library.Contexts;
using Library.Entities;
using Library.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Library.Services.Repositories
{
    public class PublishersRepository: IPublishersRepository
    {
        private readonly LibraryContext context;

        public PublishersRepository(LibraryContext context)
        {
            this.context = context;

        }

        public async Task<Publisher?> GetPublisherAsync(int? id)
        {
            return await this.context.PublishersWithBooks().FirstOrDefaultAsync(publisher => publisher.Id == id);
        }

        public async Task<IEnumerable<Publisher?>> GetPublishersAsync()
        {
            return await this.context.Publishers.ToListAsync();
        }

        public async Task AddBookToPublisherAsync(Book book, int publisherId)
        {
            var publisher = await GetPublisherAsync(publisherId);
            if (publisher != null)
            {
                publisher.Books?.Add(book);
            }
        }

        public async Task AddPublisherAsync(Publisher publisher)
        {
            await this.context.AddAsync(publisher);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync() >= 0;
        }
    }
}
