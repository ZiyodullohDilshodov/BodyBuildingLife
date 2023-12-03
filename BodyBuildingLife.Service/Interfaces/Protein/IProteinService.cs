using BodyBuildingLife.Service.DTOs.ProtainDTOs;

namespace BodyBuildingLife.Service.Interfaces.Protain;

public  interface IProteinService
{
    public Task<bool> DeleteAsync(long proteinId);
    public Task<ProteinForResultDto> RetruveByIdAsync(long id);
    public Task<IEnumerable<ProteinForResultDto>> RetrieveAllAsync();
    public Task<ProteinForResultDto> UpdateAsync(ProteinForUpdateDto forUpdateDto);
    public Task<ProteinForResultDto> CreateAsync(ProteinForCreationDto forCreationDto);
}
