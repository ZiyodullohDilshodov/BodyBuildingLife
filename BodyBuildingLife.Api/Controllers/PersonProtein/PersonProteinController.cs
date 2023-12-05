using Microsoft.AspNetCore.Mvc;
using BodyBuildingLife.Service.DTOs.PersonProtainDTOs;
using BodyBuildingLife.Service.Interfaces.PersonProtain;

namespace BodyBuildingLife.Api.Controllers.PersonProtein
{
    public class PersonProteinController : BaseController
    {
        private readonly IPersonProteinService _personProteinService;

        public PersonProteinController(IPersonProteinService personProteinService)
        {
            _personProteinService = personProteinService;
        }

        [HttpGet("{personProtein-id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "personProtein-id")]long id)
             =>Ok(await _personProteinService.RetruveByIdAsync(id));

        [HttpGet]
        public async Task<IActionResult>GetAllAsync()
            =>Ok(await _personProteinService.RetrieveAllAsync());

        [HttpPost]
        public async Task<IActionResult> CreateAsync(PersonProteinForCreationDto personProtainForCreationDto)
            => Ok(await _personProteinService.CreateAsync(personProtainForCreationDto));

        [HttpPut]
        public async Task<IActionResult>UpdateAsync(PersonProteinForUpdateDto personProtainForUpdateDto)
            =>Ok(await _personProteinService.UpdateAsync(personProtainForUpdateDto));

        [HttpDelete("{personProtein-id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "personProtein-id")]long id)
            =>Ok(await _personProteinService.DeleteAsync(id));
    }
}
