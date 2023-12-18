using BodyBuildingLife.Service.DTOs.Person;
using BodyBuildingLife.Service.DTOs.PersonDTOs;

namespace BodyBuildingLife.Service.Interfaces.Person;

public  interface IPersonService
{
    public Task<bool> DeleteAsync(long personId);
    public Task<PersonForResultDto> RetruveByIdAsync(long id);
    public Task<IEnumerable<PersonForResultDto>> RetrieveAllAsync();
    public Task<PersonForResultDto> UpdateAsync(PersonForUpdateDto forUpdateDto);
    public Task<PersonForResultDto> CreateAsync(PersonForCreationDto forCreationDto);
    public Task<PersonForResultDto> RtrieveByEmaiil(string email);
}
