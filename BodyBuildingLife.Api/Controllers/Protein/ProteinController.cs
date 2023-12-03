using Microsoft.AspNetCore.Mvc;
using BodyBuildingLife.Service.DTOs.ProtainDTOs;
using BodyBuildingLife.Service.Interfaces.Protain;

namespace BodyBuildingLife.Api.Controllers.Protein
{
    public class ProteinController:BaseController
    {
        private readonly IProteinService _proteinService;

        public ProteinController(IProteinService proteinService)
        {
            _proteinService = proteinService;
        }

        [HttpGet("{protein-id}")]
        public async Task<IActionResult> GetById([FromRoute(Name = "protein-id")]long id)
        {
            var protein = await _proteinService.RetruveByIdAsync(id);
            return  Ok(protein);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromBody] ProteinForCreationDto proteinForCreationDto)
        {
            var protein = await _proteinService.RetrieveAllAsync();
            return Ok(protein);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ProteinForCreationDto proteinForCreationDto)
        {
            var protein = await _proteinService.CreateAsync(proteinForCreationDto);
            return Ok(protein);
        }

        [HttpDelete("{protein-id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "protein-id")] long id)
        {
            var protein = await _proteinService.DeleteAsync(id);
            return Ok(protein);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]ProteinForUpdateDto proteinForUpdateDto)
        {
            var protein = await _proteinService.UpdateAsync(proteinForUpdateDto);
            return Ok(protein);
        }

    }
}
