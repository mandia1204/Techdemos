using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.PersonApi.Models;
using Demo.PersonApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PersonApi.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService personService;
        public PersonController(IPersonService personService){
            this.personService = personService;
        }

        // GET api/person
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return this.personService.GetAll();
        }

        // GET api/person/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return this.personService.GetById(id);
        }

        // POST api/person
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            return ExecuteAction(person, personService.Create);
        }

        // PUT api/person/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Person person)
        {
            return ExecuteAction(person, personService.Update);
        }

        // DELETE api/person/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return ExecuteAction(id, personService.Delete);
        }
        private IActionResult ExecuteAction<T>(T param, Func<T, ApiResponse<Person>> function) {
            var result = function(param);

            if(!result.Success) {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
