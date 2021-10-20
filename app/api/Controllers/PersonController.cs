using app.Models;
using app.Repositories;
using app.Requests;
using app.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace app.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/persons/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonController(ILogger<PersonController> logger, IPersonRepository personRepository, IMapper mapper)
        {
            _logger = logger;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personRepository.FindAll());
        }
        
        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult Get(long id)
        {
            return Ok(_personRepository.FindById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] PersonRequest request)
        {
            var person = _mapper.Map<Person>(request);
            var personSaved = _personRepository.Create(person);
            var response = _mapper.Map<PersonResponse>(personSaved);
            return CreatedAtRoute("GetPerson", new {id = response.Id}, response);
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody]PersonRequest request)
        {
            var person = _mapper.Map<Person>(request);
            var personSaved = _personRepository.Update(id, person);
            var response = _mapper.Map<PersonResponse>(personSaved);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personRepository.Delete(id);
            return NoContent();
        }
    }
}
