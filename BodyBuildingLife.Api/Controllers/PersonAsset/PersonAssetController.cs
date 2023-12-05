using Microsoft.AspNetCore.Mvc;
using BodyBuildingLife.Service.Interfaces.IPersonAsset;

namespace BodyBuildingLife.Api.Controllers.PersonAsset;

public class PersonAssetController : BaseController
{
    private readonly IPersonAssetService _personAssetService;

    public PersonAssetController(IPersonAssetService personAssetService)
    {
        _personAssetService = personAssetService;
    }

    [HttpGet("{person-id}/{personAsset-id}")]
    public async Task<IActionResult> GetByIDAsync([FromRoute(Name = "person-id")] long personId, [FromRoute(Name = "personAsset-id")] long personAssetId)
    {
        var personAsset = await _personAssetService.RetrieveByIdAsync(personId, personAssetId);
        return Ok(personAsset);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var personAsset = await _personAssetService.RetrieveAllAsync();
        return Ok(personAsset);
    }

    [HttpPost("{person-id}")]
    public async Task<IActionResult> CreateAsync([FromRoute(Name = "person-id")] long id, IFormFile formFile)
    {
        var personAsset = await _personAssetService.CreateAsync(id, formFile);
        return Ok(personAsset);
    }

    [HttpDelete("{person-id}/{personAsset-id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "person-id")] long personId, [FromRoute(Name = "personAsset-id")] long personAssetid)
    {
        var personAsset = await _personAssetService.RemoveAsync(personId, personAssetid);
        return Ok(personAsset);
    }


}
