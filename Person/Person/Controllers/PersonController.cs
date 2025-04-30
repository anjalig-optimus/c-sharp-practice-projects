using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Person_json.Entities;
using Person_json.Repository;

namespace Person_json.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonController : ControllerBase
    {
        private readonly PersonRepository _personRepository;

        public PersonController(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Post(Person person)
        {
            try
            {
                string personJson = JsonConvert.SerializeObject(person);
                await _personRepository.PostPersonData(personJson);
                return Ok(new { message = "Person data inserted successfully." });
            }
             
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error occurred", error = ex.Message });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var persons = await _personRepository.GetAllPersonsAsync();
                return Ok(persons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error occurred", error = ex.Message });
            }
        }
    }
}
