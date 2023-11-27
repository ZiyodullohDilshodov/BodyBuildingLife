using BodyBuildingLife.Service.DTOs.PersonDTOs;
using BodyBuildingLife.Service.Interfaces.Person;

namespace BodyBuildingLife.Service.Services.Person;

public class PersonServicecs : IPersonService
{
    public Task<PersonForResultDto> CreateAsync(PersonForCreationDto forCreationDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long personId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PersonForResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PersonForResultDto> RetruveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<PersonForResultDto> UpdateAsync(PersonForUpdateDto forUpdateDto)
    {
        throw new NotImplementedException();
    }
}
