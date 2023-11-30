using BodyBuildingLife.Service.DTOs.TrainerAsset;
using Microsoft.AspNetCore.Http;

namespace BodyBuildingLife.Service.Interfaces.TrainerAsset;

public  interface ITrainerAssetService
{
    Task<bool> RemoveAsync(long trainerId, long id);
    Task<TrainerAssetForResultDto> RetrieveByIdAsync(long trainerId, long id);
    Task<TrainerAssetForResultDto> CreateAsync(long trainerId, IFormFile formFile);
    Task<IEnumerable<TrainerAssetForResultDto>> RetrieveAllAsync(long trainerId);
}
