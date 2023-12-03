using Microsoft.AspNetCore.Mvc;
using BodyBuildingLife.Service.Interfaces;
using BodyBuildingLife.Service.DTOs.Standards;

namespace BodyBuildingLife.Api.Controllers.ProteinStandards
{
    public class ProteinStandardsController : BaseController
    {
        private readonly IProteinStandardsService _proteinStandardsService;

        public ProteinStandardsController(IProteinStandardsService proteinStandardsService)
        {
            _proteinStandardsService = proteinStandardsService;
        }

        [HttpGet("{person-id}/{protein-id}/{proteinStandards-id}")]
        public async Task<IActionResult> GetByIDAsync([FromRoute(Name = ("person-id"))]long personid,[FromRoute(Name = "protein-id")]long proteinid ,[FromRoute(Name = "proteinStandards-id")] long proteinStandardsId)
        {
            var proteinStandards = await _proteinStandardsService.RetrieveByIdAsync(personid,proteinid,proteinStandardsId);
            return Ok(proteinStandards);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var proteinStandards = await _proteinStandardsService.RetrieveAllAsync();
            return Ok(proteinStandards);
        }

        [HttpDelete("{person-id}/{protein-id}/{proteinStandards-id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = ("person-id"))] long personid, [FromRoute(Name = "protein-id")] long proteinid, [FromRoute(Name = "proteinStandards-id")] long proteinStandardsId)
        {
            var proteinStandards = await _proteinStandardsService.DeleteAsync(personid, proteinid, proteinStandardsId);
            return Ok(proteinStandards);
        }

        [HttpPost("{person-id}/{protein-id}/{proteinStandards-id}")]
        public async Task<IActionResult> CreateAsync([FromRoute(Name = "person-id")]long personId,[FromRoute(Name = "protein-id")]long proteinId,[FromBody] ProteinStandardsForResultDto proteinStandardsForResultDto)
        {
            var personProtein = await _proteinStandardsService.CreateAsync(personId, proteinId, proteinStandardsForResultDto);
            return Ok(personProtein);
        }

        [HttpPut("{person-id}/{protein-id}/{proteinStandards-id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name = "person-id")] long personId, [FromRoute(Name = "protein-id")] long proteinId, [FromBody] ProteinStandardsForResultDto personProteinForUpdateDto)
        {
            var personProtein = await _proteinStandardsService.UpdateAsync(personId, proteinId, personProteinForUpdateDto);
            return Ok(personProtein);
        }

    }
}
