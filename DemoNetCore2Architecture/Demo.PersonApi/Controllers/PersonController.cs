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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/person
        // [HttpPost]
        // public Person Post([FromBody] Person person)
        // {
        //     return this.personService.Create(person);
        // }
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            var result = this.personService.Create(person);

            if(!result.Success) {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/person/5
        [HttpPut("{id}")]
        public Person Put(int id, [FromBody]Person person)
        {
            //return this.personService.Create(person);
            return null;
        }

        // DELETE api/person/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
