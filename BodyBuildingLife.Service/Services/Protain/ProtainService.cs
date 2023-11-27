using BodyBuildingLife.Service.DTOs.ProtainDTOs;
using BodyBuildingLife.Service.Interfaces.Protain;

namespace BodyBuildingLife.Service.Services.Protain;

public class ProtainService : IProtainService
{
    public Task<ProtainForResultDto> CreateAsync(ProtainForCreationDto forCreationDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long protainId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProtainForResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProtainForResultDto> RetruveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<ProtainForResultDto> UpdateAsync(ProtainForUpdateDto forUpdateDto)
    {
        throw new NotImplementedException();
    }
}
