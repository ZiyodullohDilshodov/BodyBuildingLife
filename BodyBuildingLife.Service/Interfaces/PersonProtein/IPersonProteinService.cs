using BodyBuildingLife.Service.DTOs.PersonProtainDTOs;

namespace BodyBuildingLife.Service.Interfaces.PersonProtain;

public  interface IPersonProteinService
{
    public Task<bool> DeleteAsync(long personProteinId);
    public Task<PersonProteinForResultDto> RetruveByIdAsync(long id);
    public Task<IEnumerable<PersonProteinForResultDto>> RetrieveAllAsync();
    public Task<PersonProteinForResultDto> UpdateAsync(PersonProteinForUpdateDto forUpdateDto);
    public Task<PersonProteinForResultDto> CreateAsync(PersonProteinForCreationDto forCreationDto);
}
