using Microsoft.AspNetCore.Mvc;
using BodyBuildingLife.Service.DTOs.Standards;
using BodyBuildingLife.Service.Interfaces.PersonStandards;

namespace BodyBuildingLife.Api.Controllers.PersonStandard
{
    public class PersonStandardController : BaseController
    {
        private readonly IPersonStandardsService _personStandardRepository;

        public PersonStandardController(IPersonStandardsService personStandardRepository)
        {
            _personStandardRepository = personStandardRepository;
        }

        [HttpGet("{personStandard-id}")]
        public async Task<IActionResult> GetByIDAsync([FromRoute(Name = "personStandard-id")]long  id)
            => Ok(await _personStandardRepository.GetByIdAsync(id));

        [HttpGet]
        public async Task<IActionResult>GetAllAsync()
            =>Ok(await _personStandardRepository.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult>CreateAsync(PersonStandardForCreationDto personStandardForCreationDto)
            =>Ok(await _personStandardRepository.CreateAsync(personStandardForCreationDto));

        [HttpDelete("{personStandard-id}")]
        public async Task<IActionResult>DeleteAsync([FromRoute(Name = "personStandard-id")]long id)
            =>Ok(await _personStandardRepository.DeleteAsync(id));

        [HttpPut]
        public async Task<IActionResult>UpdateAsync(PersonStandardForUpdateDto personStandardForUpdateDto)
            =>Ok(await _personStandardRepository.UpdateAsync(personStandardForUpdateDto));
    }
}
