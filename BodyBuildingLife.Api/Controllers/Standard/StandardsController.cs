using Microsoft.AspNetCore.Mvc;
using BodyBuildingLife.Service.DTOs.Standards;
using BodyBuildingLife.Service.Interfaces.Standards;

namespace BodyBuildingLife.Api.Controllers.Standard;

public class StandardsController : BaseController
{
    private readonly IStandardsService _standardsService;

    public StandardsController(IStandardsService standardsService)
    {
        _standardsService = standardsService;
    }

    [HttpGet("{standard-id}")]
    public async Task<IActionResult> GetById([FromRoute(Name = "standard-id")]long id)
        =>Ok(await _standardsService.GetByIdAsync(id));

    [HttpGet]
    public async Task<IActionResult>GeAllAsync()
        =>Ok(await _standardsService.GetAllAsync());

    [HttpDelete("{standard-id}")]
    public async Task<IActionResult>DeleteAsync([FromRoute(Name = "standard-id")]long id)
        =>Ok(await _standardsService.DeleteAsync(id));

    [HttpPost]
    public async Task<IActionResult>CreateAsync(StandardForCreationDto standardForCreationDto)
        =>Ok(await _standardsService.CreateAsync(standardForCreationDto));

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(StandardForUpdateDto standardForUpdateDto)
        => Ok(await _standardsService.UpdateAsync(standardForUpdateDto));

}
