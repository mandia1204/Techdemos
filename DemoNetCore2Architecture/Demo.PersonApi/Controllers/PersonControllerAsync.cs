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
    public class PersonAsyncController : Controller
    {
        private readonly IPersonServiceAsync personService;
        public PersonAsyncController(IPersonServiceAsync personService){
            this.personService = personService;
        }

        // GET api/person
        [HttpGet]
        public Task<List<Person>> Get()
        {
            return this.personService.GetAllAsync();
        }

        // GET api/person/5
        [HttpGet("{id}")]
        public Task<Person> Get(int id)
        {
            return this.personService.GetByIdAsync(id);
        }

        // POST api/person
        [HttpPost]
        public Task<IActionResult> Post([FromBody] Person person)
        {
            return ExecuteAction(person, personService.CreateAsync);
        }

        // PUT api/person/5
        [HttpPut("{id}")]
        public Task<IActionResult> Put(int id, [FromBody]Person person)
        {
            return ExecuteAction(person, personService.UpdateAsync);
        }

        // DELETE api/person/5
        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(int id)
        {
            return ExecuteAction(id, personService.DeleteAsync);
        }
        private async Task<IActionResult> ExecuteAction<T>(T param, Func<T, Task<ApiResponse<Person>>> function) {
            var result = await function(param);

            if(!result.Success) {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
