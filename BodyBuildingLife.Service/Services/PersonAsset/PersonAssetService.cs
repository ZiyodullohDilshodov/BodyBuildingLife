using BodyBuildingLife.Service.DTOs.PersonAsset;
using BodyBuildingLife.Service.Interfaces.IPersonAsset;
using Microsoft.AspNetCore.Http;

namespace BodyBuildingLife.Service.Services.PersonAsset;

public class PersonAssetService : IPersonAssetService
{
    public Task<PersonAssetForResultDto> CreateAsync(long userId, IFormFile formFile)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long personId, long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PersonAssetForResultDto>> RetrieveAllAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<PersonAssetForResultDto> RetrieveByIdAsync(long personId, long id)
    {
        throw new NotImplementedException();
    }
}
