using Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Extensions
{
    static class LibraryFetchExtensions
    {
        public static IQueryable<Book> BooksWithAuthorAndPublisher(this Contexts.LibraryContext context)
        {
            return context.Books.Include(book => book.Author)
                .Include(book => book.Publisher);
        }

        public static IQueryable<Author> AuthorsWithBooks(this Contexts.LibraryContext context)
        {
            return context.Authors.Include(author => author.Books);
        }

        public static IQueryable<Publisher> PublishersWithBooks(this Contexts.LibraryContext context)
        {
            return context.Publishers.Include(publisher => publisher.Books);
        }
    }
}
