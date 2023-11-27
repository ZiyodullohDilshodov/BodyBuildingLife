using BodyBuildingLife.Service.DTOs.ProtainDTOs;

namespace BodyBuildingLife.Service.Interfaces.Protain;

public  interface IProtainService
{
    public Task<bool> DeleteAsync(long protainId);
    public Task<ProtainForResultDto> RetruveByIdAsync(long id);
    public Task<IEnumerable<ProtainForResultDto>> RetrieveAllAsync();
    public Task<ProtainForResultDto> UpdateAsync(ProtainForUpdateDto forUpdateDto);
    public Task<ProtainForResultDto> CreateAsync(ProtainForCreationDto forCreationDto);
}
