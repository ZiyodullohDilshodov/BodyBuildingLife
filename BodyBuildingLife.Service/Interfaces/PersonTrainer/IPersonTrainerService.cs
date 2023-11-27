using BodyBuildingLife.Service.DTOs.PersonProtainDTOs;
using BodyBuildingLife.Service.DTOs.PersonTrainerDTOs;

namespace BodyBuildingLife.Service.Interfaces.PersonTrainer;

public  interface IPersonTrainerService
{
    public Task<bool> DeleteAsync(long personTrainerId);
    public Task<PersonTrainerForResultDto> RetruveByIdAsync(long id);
    public Task<IEnumerable<PersonTrainerForResultDto>> RetrieveAllAsync();
    public Task<PersonTrainerForResultDto> UpdateAsync(PersonTrainerForUpdateDto forUpdateDto);
    public Task<PersonTrainerForResultDto> CreateAsync(PersonProtainForCreationDto forCreationDto);
}
