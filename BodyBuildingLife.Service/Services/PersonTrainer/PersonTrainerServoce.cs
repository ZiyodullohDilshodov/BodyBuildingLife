using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Service.Exceptions;
using BodyBuildingLife.Service.DTOs.PersonTrainerDTOs;
using BodyBuildingLife.Domain.Entities.PersonTreainers;
using BodyBuildingLife.Service.Interfaces.PersonTrainer;

namespace BodyBuildingLife.Service.Services;

public class PersonTrainerServoce : IPersonTrainerService
{
    private readonly IMapper _mapper;
    private readonly IPersonService _personRepository;
    private readonly ITrainerRepository _trainerRepository;
    private readonly IPersonTrainerRepository _personTrainerRepository;

    public PersonTrainerServoce(IMapper mapper,
                                IPersonService personRepository,
                                ITrainerRepository trainerRepository,
                                IPersonTrainerRepository personTrainerRepository)
    {
        _mapper = mapper;
        _personRepository = personRepository;
        _trainerRepository = trainerRepository;
        _personTrainerRepository = personTrainerRepository;
    }

    public async Task<PersonTrainerForResultDto> CreateAsync(PersonTrainerForCreationDto forCreationDto)
    {
        var person = await _personRepository.RetriveAllAsync()
            .Where(p=>p.Id == forCreationDto.PersonID)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (person is null || person.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Person is not found");


        var trainer = await _trainerRepository.RetriveAllAsync()
            .Where(t=>t.Id == forCreationDto.TrainerID)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (trainer is null || person.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Trainer is not found");



        var selection = await _personTrainerRepository.RetriveAllAsync().ToListAsync();
        foreach (var item in selection)
        {
            if(item.TraionerId == forCreationDto.TrainerID && item.PersonId == forCreationDto.PersonID)
                throw new BodyBuildingLifeException(404, "Person and Trainer already exists");
        }    

        var mappedPersonTrainer = _mapper.Map<PersonTrainer>(forCreationDto);
        mappedPersonTrainer.CreateAtt = DateTime.UtcNow;
        var createPersonTrainer = await _personTrainerRepository.CreateAsync(mappedPersonTrainer);
        
        return _mapper.Map<PersonTrainerForResultDto>(createPersonTrainer);

    }

    public async Task<bool> DeleteAsync(long personTrainerId)
    {
        var personTariner = await _personTrainerRepository.RetriveAllAsync()
            .Where(pt=>pt.Id == personTrainerId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personTariner is null)
            throw new BodyBuildingLifeException(404, "PersonTrainer is not found");

        return  await _personTrainerRepository.DeleteAsync(personTrainerId);
            
    }

    public async Task<IEnumerable<PersonTrainerForResultDto>> RetrieveAllAsync()
    {
        var personTrainers = await _personTrainerRepository.RetriveAllAsync()
            .Include(pt=>pt.Trainer)
            .Include(pt=>pt.Person)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<PersonTrainerForResultDto>>(personTrainers);
    }

    public async Task<PersonTrainerForResultDto> RetruveByIdAsync(long id)
    {
        var PersonTrainer = await _personTrainerRepository.RetriveAllAsync()
            .Where(pt=>pt.Id == id)
            .Include(pt=>pt.Person)
            .Include(pt=>pt.Trainer)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (PersonTrainer is null)
            throw new BodyBuildingLifeException(404, "PersonTrainer is not found");

        return _mapper.Map<PersonTrainerForResultDto>(PersonTrainer);
    }

    public async Task<PersonTrainerForResultDto> UpdateAsync(PersonTrainerForUpdateDto forUpdateDto)
    {
        var personTrainer = await _personTrainerRepository.RetriveAllAsync()
            .Where(pt => pt.Id == forUpdateDto.Id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personTrainer is null)
            throw new BodyBuildingLifeException(404, "PersonTrainer is not found");

        var mappedPersonTrainer = _mapper.Map<PersonTrainer>(personTrainer);
        mappedPersonTrainer.UpdateAtt = DateTime.UtcNow;
        var updatePersonTrainer = await _personTrainerRepository.UpdateAsync(mappedPersonTrainer);

        return _mapper.Map<PersonTrainerForResultDto>(updatePersonTrainer);
    }
}
