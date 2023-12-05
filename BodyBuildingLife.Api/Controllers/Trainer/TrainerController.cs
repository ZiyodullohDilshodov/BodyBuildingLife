using Microsoft.AspNetCore.Mvc;
using BodyBuildingLife.Service.DTOs.TrainerDTOs;
using BodyBuildingLife.Service.Interfaces.Trainers;

namespace BodyBuildingLife.Api.Controllers.Trainer
{
    public class TrainerController : BaseController
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet("{trainer-id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "trainer-id")]long id) 
        {
            var trainer = await _trainerService.RetruveByIdAsync(id);
            return Ok(trainer);
        }

        [HttpGet]
        public async Task<IActionResult>GetAsync()
        {
            var trainer = await _trainerService.RetrieveAllAsync();
            return Ok(trainer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(TrainerForCreationDto trainerForCreationDto)
        {
            var trainer = await _trainerService.CreateAsync(trainerForCreationDto);
            return Ok(trainer);
        }


        [HttpDelete("{trainer-id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "trainer-id")]long id) 
        { 
            var trainer = await _trainerService.DeleteAsync(id);
            return Ok(trainer);
        
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]TrainerForUpdateDto trainerForUpdateDto)
        {
            var trainer = await _trainerService.UpdateAsync(trainerForUpdateDto);
            return Ok(trainer);

        }
    }
}
