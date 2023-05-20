using ArtExchange.Application.Feautures.Persons.Commands.Add;
using ArtExchange.Application.Feautures.Persons.Queries;
using ArtExchange.Application.Feautures.Persons.Queries.GetPerson;
using ArtExchange.Application.Feautures.Persons.Queries.GetPersonsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArtExchange.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonVm>>> Get()
        {
            return await _mediator.Send(new GetPersonsListQuery());
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonVm>>Get(long id)
        {
            var personVm = await _mediator.Send(new GetPersonQuery { Id = id});
            if(personVm == null)
                return NotFound();
            return Ok(personVm);
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreatePersonCommand createPersonCommand)
        {
            var id = await _mediator.Send(createPersonCommand);
            return Ok(id);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
