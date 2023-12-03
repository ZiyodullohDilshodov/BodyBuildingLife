using Microsoft.AspNetCore.Mvc;
using BodyBuildingLife.Service.DTOs.PersonProtainDTOs;
using BodyBuildingLife.Service.Interfaces.PersonProtain;

namespace BodyBuildingLife.Api.Controllers.PersonProtein;

public class PersonProteinController : BaseController
{
    private readonly IPersonProteinService _personProteinService;

    public PersonProteinController(IPersonProteinService personProteinService)
    {
        _personProteinService = personProteinService;
    }

    [HttpGet("{personProtein-id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "personProtein-id")] long id)
    {
        var personProtein = await _personProteinService.RetruveByIdAsync(id);
        return Ok(personProtein);
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAsync()
    //{
    //    var personProtein = await _personProteinService.RetrieveAllAsync();
    //    return Ok(personProtein);
    //}

    //[HttpDelete("{personProtein-id}")]
    //public async Task<IActionResult> DeleteAsync([FromRoute(Name = "personProtein-id")] long id)
    //{
    //    var personProtein = await _personProteinService.DeleteAsync(id);
    //    return Ok(personProtein);
    //}

    //[HttpPost]
    //public async Task<IActionResult> CreateAsync([FromBody] PersonProtainForCreationDto personProteinForCreationDto)
    //{
    //    var personProtein = await _personProteinService.CreateAsync(personProteinForCreationDto);
    //    return Ok(personProtein);
    //}

    //[HttpPut]
    //public async Task<IActionResult> UpdateAsync([FromBody] PersonProtainForUpdateDto personProteinForUpdateDto)
    //{
    //    var personProtein = await _personProteinService.UpdateAsync(personProteinForUpdateDto);
    //    return Ok(personProtein);
    //}

}
