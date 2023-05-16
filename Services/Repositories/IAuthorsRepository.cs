using Library.Entities;

namespace Library.Services.Repositories
{
    public interface IAuthorsRepository
    {
        Task<Author?> GetAuthorAsync(int? id);
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<bool> AddAuthorAsync(Author author);
        Task<bool> AddBookToAuthorAsync(Book book, int authorId);
    }
}
