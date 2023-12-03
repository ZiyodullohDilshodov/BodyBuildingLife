using Microsoft.AspNetCore.Mvc;
using BodyBuildingLife.Service.DTOs.PersonDTOs;
using BodyBuildingLife.Service.Interfaces.Person;

namespace BodyBuildingLife.Api.Controllers.Person
{
    public class PersonController : BaseController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("{person-id}")]
        public async Task<IActionResult> GetByIDAsync([FromRoute(Name = "person-id")] long id)
        {
            var person = await _personService.RetruveByIdAsync(id);
            return Ok(person);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var person = await _personService.RetrieveAllAsync();
            return Ok(person);
        }

        [HttpDelete("{person-id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "person-id")]long id)
        {
            var person = await _personService.DeleteAsync(id);
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PersonForCreationDto personForCreationDto)
        {
            var person = await _personService.CreateAsync(personForCreationDto);
            return Ok(person);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]PersonForUpdateDto personForUpdateDto)
        {
            var person =await _personService.UpdateAsync(personForUpdateDto);
            return Ok(person);
        }
    }
}
