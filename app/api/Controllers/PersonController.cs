using app.Models;
using app.Requests;
using app.Responses;
using app.Services;
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
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(ILogger<PersonController> logger, IPersonService personService, IMapper mapper)
        {
            _logger = logger;
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }
        
        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult Get(long id)
        {
            return Ok(_personService.FindById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] PersonRequest request)
        {
            var person = _mapper.Map<Person>(request);
            var personSaved = _personService.Create(person);
            var response = _mapper.Map<PersonResponse>(personSaved);
            return CreatedAtRoute("GetPerson", new {id = response.Id}, response);
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody]PersonRequest request)
        {
            var person = _mapper.Map<Person>(request);
            var personSaved = _personService.Update(id, person);
            var response = _mapper.Map<PersonResponse>(personSaved);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
