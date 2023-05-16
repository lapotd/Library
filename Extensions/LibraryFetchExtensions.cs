using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Library.Extensions
{
    static class LibraryFetchExtensions
    {
        public static IQueryable<Book> BooksWithAuthorAndPublisher(this IDatabaseService database)
        {
            return database.Books.Include(book => book.Author)
                .Include(book => book.Publisher);
        }

        public static IQueryable<Author> AuthorsWithBooks(this IDatabaseService database)
        {
            return database.Authors.Include(author => author.Books);
        }

        public static IQueryable<Publisher> PublishersWithBooks(this IDatabaseService database)
        {
            return database.Publishers.Include(publisher => publisher.Books);
        }
    }
}
