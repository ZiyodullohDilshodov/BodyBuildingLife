using BodyBuildingLife.Service.DTOs.PersonAsset;
using Microsoft.AspNetCore.Http;

namespace BodyBuildingLife.Service.Interfaces.IPersonAsset;

public  interface IPersonAssetService
{
    Task<bool> RemoveAsync(long personId, long id);
    Task<PersonAssetForResultDto> RetrieveByIdAsync(long personId, long id);
    Task<PersonAssetForResultDto> CreateAsync(long userId, IFormFile formFile);
    Task<IEnumerable<PersonAssetForResultDto>> RetrieveAllAsync();
}
