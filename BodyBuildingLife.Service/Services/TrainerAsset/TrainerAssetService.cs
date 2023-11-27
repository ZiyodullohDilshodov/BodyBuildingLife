using BodyBuildingLife.Service.DTOs.TrainerAsset;
using BodyBuildingLife.Service.Interfaces.TrainerAsset;
using Microsoft.AspNetCore.Http;

namespace BodyBuildingLife.Service.Services.TrainerAsset;

public class TrainerAssetService : ITrainerAssetService
{
    public Task<TrainerAssetForResultDto> CreateAsync(long trainerId, IFormFile formFile)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long trainerAssetId, long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TrainerAssetForResultDto>> RetrieveAllAsync(long trainerId)
    {
        throw new NotImplementedException();
    }

    public Task<TrainerAssetForResultDto> RetrieveByIdAsync(long trainerId, long id)
    {
        throw new NotImplementedException();
    }
}
