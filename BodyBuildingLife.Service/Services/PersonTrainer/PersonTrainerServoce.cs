using BodyBuildingLife.Service.DTOs.PersonProtainDTOs;
using BodyBuildingLife.Service.DTOs.PersonTrainerDTOs;
using BodyBuildingLife.Service.Interfaces.PersonTrainer;

namespace BodyBuildingLife.Service.Services.PersonTrainer;

public class PersonTrainerServoce : IPersonTrainerService
{
    public Task<PersonTrainerForResultDto> CreateAsync(PersonProtainForCreationDto forCreationDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long personTrainerId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PersonTrainerForResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PersonTrainerForResultDto> RetruveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<PersonTrainerForResultDto> UpdateAsync(PersonTrainerForUpdateDto forUpdateDto)
    {
        throw new NotImplementedException();
    }
}
