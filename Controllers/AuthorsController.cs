using AutoMapper;
using Library.Entities;
using Library.Models.ReturnDto;
using Library.Services.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsRepository authorsRepository;
        private readonly IMapper mapper;

        public AuthorsController(IAuthorsRepository authorsRepository, IMapper mapper)
        {
            this.authorsRepository = authorsRepository ?? throw new ArgumentNullException(nameof(authorsRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorForReturnDto>>> GetAuthors()
        {
            var authors = this.mapper.Map<IEnumerable<AuthorForReturnDto>>(await this.authorsRepository.GetAuthorsAsync());
            if(authors == null)
            {
                return NotFound();
            }
            return Ok(authors);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorForReturnDto>> PostAuthor(AuthorForCreationDto author)
        {
            if (author.Name == null || author.Description == null)
            {
                return BadRequest();
            }
            var uploadedAuthor = this.mapper.Map<Author>(author);
            await this.authorsRepository.AddAuthorAsync(uploadedAuthor);
            if(!await this.authorsRepository.SaveChangesAsync())
            {
                return BadRequest();
            }
            var returnedAuthor = this.mapper.Map<AuthorForReturnDto>(uploadedAuthor);
            return Ok(returnedAuthor);
        }
    }
}
