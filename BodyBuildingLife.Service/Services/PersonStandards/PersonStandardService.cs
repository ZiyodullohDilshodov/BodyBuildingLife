using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Service.Exceptions;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Service.DTOs.Standards;
using BodyBuildingLife.Domain.Entities.PersonStandards;
using BodyBuildingLife.Service.Interfaces.PersonStandards;

namespace BodyBuildingLife.Service.Services.PersonStandards;

public class PersonStandardService : IPersonStandardsService
{

    private readonly IMapper _mapper;
    private readonly IStandardsRepository _standardsRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IPersonStandardRepository _personStandardsRepository;

    public PersonStandardService(IMapper mapper ,
                                 IPersonRepository personRepository,
                                 IStandardsRepository standardsRepository,
                                 IPersonStandardRepository personStandardRepository)
    {
        _mapper = mapper;
        _personRepository = personRepository;
        _standardsRepository = standardsRepository;
        _personStandardsRepository = personStandardRepository;
    }

    public async Task<PersonStandardForResultDto> CreateAsync(PersonStandardForCreationDto personStandardForCreationDto)
    {
        var person = await _personRepository.RetriveAllAsync()
            .Where(p=>p.Id == personStandardForCreationDto.PersonId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (person is null)
            throw new BodyBuildingLifeException(404, "Person is not found");

        var standards = await _standardsRepository.RetriveAllAsync()
            .Where(s=>s.Id == personStandardForCreationDto.StandardID)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (standards is null)
            throw new BodyBuildingLifeException(404, "Standards is not found");

        var personStandards = await _personStandardsRepository.RetriveAllAsync().AsNoTracking().ToListAsync();

        foreach(var personStandard in personStandards)
        {
            if (personStandard.StandardID == personStandardForCreationDto.StandardID && personStandard.PersonId == personStandardForCreationDto.PersonId)
                throw new BodyBuildingLifeException(409, "PersonStandards already  exists");
        }

        var mapped = _mapper.Map<PersonStandard>(personStandardForCreationDto);
        var createPersonStandards = await _personStandardsRepository.CreateAsync(mapped);
        return _mapper.Map<PersonStandardForResultDto>(createPersonStandards);

    }

    public async Task<bool> DeleteAsync(long id)
    {
        var personStandards = await _personStandardsRepository.RetriveAllAsync()
            .Where(s => s.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personStandards is null)
            throw new BodyBuildingLifeException(404, "PersonStandards is not found");

        return  await _personStandardsRepository.DeleteAsync(id);

    }

    public async Task<IEnumerable<PersonStandardForResultDto>> GetAllAsync()
    {
        var personStandards = await _personStandardsRepository.RetriveAllAsync().AsNoTracking().ToListAsync();
        return  _mapper.Map<IEnumerable<PersonStandardForResultDto>>(personStandards);
    }

    public async Task<PersonStandardForResultDto> GetByIdAsync(long id)
    {
        var personStandards = await _personStandardsRepository.RetriveAllAsync()
            .Where(ps => ps.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personStandards is null)
            throw new BodyBuildingLifeException(404, "PersonStandard is not found");

        return _mapper.Map<PersonStandardForResultDto>(personStandards);
    }

    public async Task<PersonStandardForResultDto> UpdateAsync(PersonStandardForUpdateDto standardForUpdateDto)
    {
        var personStandards = await _personStandardsRepository.RetriveAllAsync()
            .Where(ps => ps.Id == standardForUpdateDto.Id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personStandards is null)
            throw new BodyBuildingLifeException(440, "PersonStandard is not found");

        var mapped = _mapper.Map<PersonStandard>(standardForUpdateDto);
        mapped.UpdateAtt = DateTime.UtcNow;
        var updatePersonStandards = await _personStandardsRepository.UpdateAsync(mapped);
        return _mapper.Map<PersonStandardForResultDto>(updatePersonStandards);
    }
}
