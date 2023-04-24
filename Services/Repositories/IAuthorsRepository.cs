using Library.Entities;

namespace Library.Services.Repositories
{
    public interface IAuthorsRepository
    {
        Task<Author?> GetAuthor(int id);
        Task<IEnumerable<Author?>> GetAuthors();
        Task<bool> AddBookToAuthor(Book book, int authorId);
        Task<bool> SaveChangesAsync();
    }
}
