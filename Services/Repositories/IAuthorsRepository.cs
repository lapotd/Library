using Library.Entities;

namespace Library.Services.Repositories
{
    public interface IAuthorsRepository
    {
        Task<Author?> GetAuthorAsync(int? id);
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task AddAuthorAsync(Author author);
        Task AddBookToAuthorAsync(Book book, int authorId);
        Task<bool> SaveChangesAsync();
    }
}
