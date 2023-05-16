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
    [Route("api/publishers")]

    public class PublishersController : ControllerBase
    {

        private readonly IPublishersRepository publishersRepository;
        private readonly IMapper mapper;

        public PublishersController(IPublishersRepository publishersRepository, IMapper mapper)
        {
            this.publishersRepository = publishersRepository ?? throw new ArgumentNullException(nameof(publishersRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnPublisherDto>>> GetPublishers()
        {
            var publishers = mapper.Map<IEnumerable<ReturnPublisherDto>>(await this.publishersRepository.GetPublishersAsync());
            if (!publishers.Any())
            {
                return BadRequest();
            }
            return Ok(publishers);
        }

        [HttpPost]
        public async Task<ActionResult<ReturnPublisherDto>> PostPublisher(CreatePublisherDto publisher)
        {
            if(publisher.Name == null || publisher.Description == null)
            {
                return BadRequest();
            }
            var uploadedPublisher = this.mapper.Map<Publisher>(publisher);
            await this.publishersRepository.AddPublisherAsync(uploadedPublisher);
            if(!(await this.publishersRepository.SaveChangesAsync()))
            {
                return BadRequest();
            }
            var returnedPublisher = this.mapper.Map<ReturnPublisherDto>(uploadedPublisher);
            return Ok(returnedPublisher);
        }

    }
}
