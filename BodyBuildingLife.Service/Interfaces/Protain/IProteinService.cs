using BodyBuildingLife.Service.DTOs.ProtainDTOs;

namespace BodyBuildingLife.Service.Interfaces.Protain;

public  interface IProteinService
{
    public Task<bool> DeleteAsync(long proteinId);
    public Task<ProtainForResultDto> RetruveByIdAsync(long id);
    public Task<IEnumerable<ProtainForResultDto>> RetrieveAllAsync();
    public Task<ProtainForResultDto> UpdateAsync(ProtainForUpdateDto forUpdateDto);
    public Task<ProtainForResultDto> CreateAsync(ProtainForCreationDto forCreationDto);
}
