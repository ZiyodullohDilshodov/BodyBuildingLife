using Microsoft.AspNetCore.Mvc;
using BodyBuildingLife.Service.Interfaces.TrainerAsset;
using System.ComponentModel.DataAnnotations;

namespace BodyBuildingLife.Api.Controllers.TrainerAsset
{
    public class TrainerAssetController : BaseController
    {
        private readonly ITrainerAssetService _trainerAssetService;

        public TrainerAssetController(ITrainerAssetService trainerAssetService)
        {
            _trainerAssetService = trainerAssetService;
        }

        [HttpGet("{trainer-id}/{trainerAsset-id}")]
        public async Task<IActionResult> GetByIDAsync([FromRoute(Name = "trainer-id")] long trainerId, [FromRoute(Name = "trainerAsset-id")] long trainerAssetId)
        {
            var trainerAsset = await _trainerAssetService.RetrieveByIdAsync(trainerId, trainerAssetId);
            return Ok(trainerAsset);
        }

        [HttpGet("{trainerAsset-id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "trainerAsset-id")] long id)
        {
            var trainerAsset = await _trainerAssetService.RetrieveAllAsync(id);
            return Ok(trainerAsset);
        }

        [HttpPost("{trainer-id}")]
        public async Task<IActionResult> CreateAsync([FromRoute(Name = "trainer-id")] long id,[Required][FromBody]IFormFile formFile)
        {
            var trainerAsset = await _trainerAssetService.CreateAsync(id, formFile);
            return Ok(trainerAsset);
        }

        [HttpDelete("{trainer-id}/{trainerAsset-id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "trainer-id")] long trainerId, [FromRoute(Name = "trainerAsset-id")] long trainerAssetId)
        {
            var trainerAsset = await _trainerAssetService.RemoveAsync(trainerId, trainerAssetId);
            return Ok(trainerAsset);
        }

    }
}
