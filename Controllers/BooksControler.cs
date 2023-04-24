using AutoMapper;
using Library.Entities;
using Library.Models.ReturnDto;
using Library.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksControler : ControllerBase
    {
        private readonly IBooksRepository booksRepository;
        private readonly IAuthorsRepository authorsRepository;
        private readonly IPublishersRepository publishersRepository;
        private readonly IMapper mapper;

        public BooksControler(IBooksRepository booksRepository,
            IAuthorsRepository authorsRepository,
            IPublishersRepository publishersRepository, IMapper mapper)
        {
            this.booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
            this.authorsRepository = authorsRepository ?? throw new ArgumentNullException(nameof(authorsRepository));
            this.publishersRepository = publishersRepository ?? throw new ArgumentNullException(nameof(publishersRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookForReturnDto>> GetBook(int id)
        {
            var book = mapper.Map<BookForReturnDto>(await this.booksRepository.GetBookAsync(id));
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookForReturnDto>>> GetBooks()
        {
            var books = mapper.Map<IEnumerable<BookForReturnDto>>(await this.booksRepository.GetBooksAsync());
            if (!books.Any())
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult<BookForReturnDto>> PostBook(BookForCreationDto book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            var uploadedBook = this.mapper.Map<Book>(book);
            var author = await this.authorsRepository.GetAuthorAsync(book.AuthorId);
            var publisher = await this.publishersRepository.GetPublisherAsync(book.PublisherId);
            uploadedBook.Author = author;
            uploadedBook.Publisher = publisher;
            await this.booksRepository.AddBookAsync(uploadedBook);
            if (publisher == null || author == null || !await this.booksRepository.SaveChangesAsync())
            {
                return BadRequest();
            }
            await this.authorsRepository.AddBookToAuthorAsync(uploadedBook, uploadedBook.AuthorId);
            await this.publishersRepository.AddBookToPublisherAsync(uploadedBook, uploadedBook.PublisherId);
            if (!(await this.publishersRepository.SaveChangesAsync() && await this.authorsRepository.SaveChangesAsync()))
            {
                return BadRequest();
            }
            var returnedBook = this.mapper.Map<BookForReturnDto>(uploadedBook);
            return Ok(returnedBook);

        }
    }
}
