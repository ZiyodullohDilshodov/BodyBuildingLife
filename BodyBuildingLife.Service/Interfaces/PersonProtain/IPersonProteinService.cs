using BodyBuildingLife.Service.DTOs.PersonProtainDTOs;

namespace BodyBuildingLife.Service.Interfaces.PersonProtain;

public  interface IPersonProteinService
{
    public Task<bool> DeleteAsync(long personProteinId);
    public Task<PersonProtainForResultDto> RetruveByIdAsync(long id);
    public Task<IEnumerable<PersonProtainForResultDto>> RetrieveAllAsync();
    public Task<PersonProtainForResultDto> UpdateAsync(PersonProtainForUpdateDto forUpdateDto);
    public Task<PersonProtainForResultDto> CreateAsync(PersonProtainForCreationDto forCreationDto);
}
