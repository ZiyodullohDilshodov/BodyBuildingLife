using BodyBuildingLife.Service.DTOs.PersonProtainDTOs;
using BodyBuildingLife.Service.Interfaces.PersonProtain;

namespace BodyBuildingLife.Service.Services.PersonProtain;

public class PersonProtainService : IPersonProtainService
{
    public Task<PersonProtainForResultDto> CreateAsync(PersonProtainForCreationDto forCreationDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long personProtainId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PersonProtainForResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PersonProtainForResultDto> RetruveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<PersonProtainForResultDto> UpdateAsync(PersonProtainForUpdateDto forUpdateDto)
    {
        throw new NotImplementedException();
    }
}
