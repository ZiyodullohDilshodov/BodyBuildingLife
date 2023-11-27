using BodyBuildingLife.Service.DTOs.TrainerDTOs;

namespace BodyBuildingLife.Service.Interfaces.Trainers;

public  interface ITrainerService
{
    public Task<bool> DeleteAsync(long trainerId);
    public Task<TrainerForResultDto> RetruveByIdAsync(long id);
    public Task<IEnumerable<TrainerForResultDto>> RetrieveAllAsync();
    public Task<TrainerForResultDto> UpdateAsync(TrainerForUpdateDto forUpdateDto);
    public Task<TrainerForResultDto> CreateAsync(TrainerForCreationDto forCreationDto);
}
