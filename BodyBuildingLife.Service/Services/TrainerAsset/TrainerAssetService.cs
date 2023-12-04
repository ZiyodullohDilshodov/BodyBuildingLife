using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Service.Helpers;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Service.Exceptions;
using BodyBuildingLife.Domain.Entities.Assets;
using BodyBuildingLife.Service.DTOs.TrainerAsset;
using BodyBuildingLife.Service.Interfaces.TrainerAsset;

namespace BodyBuildingLife.Service.Services;

public class TrainerAssetService : ITrainerAssetService
{
    private readonly IMapper _mapper;
    private readonly ITrainerRepository _trainerRepository;
    private readonly ITrainerAssetRepository _trainerAssetRepository;

    public TrainerAssetService(IMapper mapper,
                               ITrainerRepository trainerRepository,
                               ITrainerAssetRepository trainerAssetRepository)
    {
        _mapper = mapper;
        _trainerRepository = trainerRepository;
        _trainerAssetRepository = trainerAssetRepository;
    }

    public async Task<TrainerAssetForResultDto> CreateAsync(long trainerId, IFormFile formFile)
    {
        var trainer = await _trainerRepository.RetriveAllAsync()
            .Where(t => t.Id == trainerId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (trainer is null || trainer.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Person is not found");

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(formFile.FileName);
        var rootPath = Path.Combine(WebHostEnvarement.WebRootPath, "Media", "Trainers", "TrainerAssets", fileName);

        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        var mappedAsset = new TrainerAsset()
        {
            TrainerId = trainerId,
            Name = formFile.Name,
            Size = formFile.Length,
            Type = formFile.ContentType,
            CreateAtt = DateTime.UtcNow,
            Extension = Path.GetExtension(formFile.FileName),
            Path = Path.Combine("Media", "Trainers", "TrainerAssets", formFile.FileName)
        }; 

        var result = await _trainerAssetRepository.CreateAsync(mappedAsset);

        return _mapper.Map<TrainerAssetForResultDto>(result);

    }

    public async Task<bool> RemoveAsync(long trainerId, long id)
    {
        var trainer = await _trainerRepository.RetriveAllAsync()
            .Where(t=>t.Id == trainerId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (trainer is null)
            throw new BodyBuildingLifeException(404, "Trainer is not found");

        var trainerAsset = await _trainerAssetRepository.RetriveAllAsync()
            .Where(ta=>ta.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (trainerAsset is null)
            throw new BodyBuildingLifeException(404, "TrainerAsset is not found");

        return await _trainerAssetRepository.DeleteAsync(trainerAsset.Id);
    }

    public async Task<IEnumerable<TrainerAssetForResultDto>> RetrieveAllAsync(long trainerId)
    {
        var trainerAssets = _trainerAssetRepository.RetriveAllAsync();
        return _mapper.Map<IEnumerable<TrainerAssetForResultDto>>(trainerAssets);

    }

    public async Task<TrainerAssetForResultDto> RetrieveByIdAsync(long trainerId, long id)
    {
        var trainer = await _trainerRepository.RetriveAllAsync()
            .Where(t=>t.Id == trainerId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (trainer is null)
            throw new  BodyBuildingLifeException(404, "Trainer is not found");

        var trainerAsset = await _trainerAssetRepository.RetriveAllAsync()
            .Where(ta => ta.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (trainerAsset is null)
            throw new BodyBuildingLifeException(404, "TrainerAsset is not found");

        return _mapper.Map<TrainerAssetForResultDto>(trainerAsset);
                
    }
}
