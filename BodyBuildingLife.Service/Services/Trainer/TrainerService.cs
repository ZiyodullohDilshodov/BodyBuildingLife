using BodyBuildingLife.Service.DTOs.TrainerDTOs;
using BodyBuildingLife.Service.Interfaces.Trainers;

namespace BodyBuildingLife.Service.Services.Trainer;

public class TrainerService : ITrainerService
{
    public Task<TrainerForResultDto> CreateAsync(TrainerForCreationDto forCreationDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long trainerId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TrainerForResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TrainerForResultDto> RetruveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<TrainerForResultDto> UpdateAsync(TrainerForUpdateDto forUpdateDto)
    {
        throw new NotImplementedException();
    }
}
