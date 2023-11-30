using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Service.Exceptions;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.Trainers;
using BodyBuildingLife.Service.DTOs.TrainerDTOs;
using BodyBuildingLife.Service.Interfaces.Trainers;

namespace BodyBuildingLife.Service.Services;

public class TrainerService : ITrainerService
{
    private readonly IMapper _mapper;
    private readonly ITrainerRepository _trainerRepository;

    public TrainerService(IMapper mapper , ITrainerRepository trainerRepository)
    {
        _mapper = mapper;
        _trainerRepository = trainerRepository;
    }

    public async Task<TrainerForResultDto> CreateAsync(TrainerForCreationDto forCreationDto)
    {
        var trainer = await _trainerRepository.RetriveAllAsync()
            .Where(t=>t.Id == forCreationDto.Id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (trainer is not null)
            throw new BodyBuildingLifeException(409, "Trainer already exists");

        var mappedTrainer = _mapper.Map<Trainer>(trainer);
        var createTrainer = await _trainerRepository.CreateAsync(mappedTrainer);
        return _mapper.Map<TrainerForResultDto>(createTrainer);

    }

    public async Task<bool> DeleteAsync(long trainerId)
    {
        var trainer = await _trainerRepository.RetriveAllAsync()
            .Where(t=>t.Id == trainerId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (trainer is null)
            throw new BodyBuildingLifeException(404, "Trainer is not found");

        return  await _trainerRepository.DeleteAsync(trainerId);

    }

    public async Task<IEnumerable<TrainerForResultDto>> RetrieveAllAsync()
    {
        var tariners = await _trainerRepository.RetriveAllAsync()
            .Include(p => p.Persons)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<TrainerForResultDto>>(tariners);
        
    }

    public async Task<TrainerForResultDto> RetruveByIdAsync(long id)
    {
        var trainer = await _trainerRepository.RetriveAllAsync()
            .Where(t => t.Id == id)
            .Include(t => t.Persons)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (trainer is null)
            throw new BodyBuildingLifeException(404, "Trainer is not found");
        
        return _mapper.Map<TrainerForResultDto>(trainer);
    }

    public async Task<TrainerForResultDto> UpdateAsync(TrainerForUpdateDto forUpdateDto)
    {
        var trainer = await _trainerRepository.RetriveAllAsync()
            .Where(t => t.Id == forUpdateDto.Id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (trainer is null)
            throw new BodyBuildingLifeException(404, "Trainer is not found");

        var updateTrainer = await _trainerRepository.UpdateAsync(trainer);
        return _mapper.Map<TrainerForResultDto>(updateTrainer);
        
    }
}
