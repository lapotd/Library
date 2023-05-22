using Library.Models.ReturnDto;

namespace Library.Commands.CreateBook
{
    public interface ICreateBookCommand
    {
        void Execute(CreateBookDto model);
    }
}
