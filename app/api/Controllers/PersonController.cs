using System.Globalization;
using app.Models;
using app.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace app.Controllers
{
    [ApiController]
    [Route("/persons")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
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
        public IActionResult Create([FromBody] Person person)
        {
            return CreatedAtRoute("GetPerson", new {id = person.Id}, person);
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Person person)
        {
           
            return NoContent();
        }
    }
}
