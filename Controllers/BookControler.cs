using AutoMapper;
using Library.Models.ReturnDto;
using Library.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookControler : ControllerBase
    {
        private readonly IBooksRepository booksRepository;
        private readonly IMapper mapper;

        public BookControler(IBooksRepository booksRepository, IMapper mapper)
        {
            this.booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookForReturnDto>> GetBook(int id)
        {
            var book = mapper.Map<BookForReturnDto>(await this.booksRepository.GetBookAsync(id));
            return book != null ? NotFound() : Ok(book);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookForReturnDto>>> GetBooks()
        {
            var books = mapper.Map<IEnumerable<BookForReturnDto>>(await this.booksRepository.GetBooksAsync());
            return books != null ? NotFound() : Ok();
        }
    }
}
