using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Service.Exceptions;
using BodyBuildingLife.Service.DTOs.Person;
using BodyBuildingLife.Service.DTOs.PersonDTOs;
using BodyBuildingLife.Domain.Entities.Persons;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Service.Interfaces.Person;

namespace BodyBuildingLife.Service.Services;

public class PersonService : IPersonService
{
    private readonly IMapper _mapper;
    private readonly IPersonRepository _personRepository;
   

    public PersonService(IPersonRepository personRepository ,IMapper mapper)
    {
        _mapper = mapper;
        _personRepository = personRepository;
       
    }

    public async Task<PersonForResultDto> CreateAsync(PersonForCreationDto forCreationDto)
    {

        var person = await  _personRepository.RetriveAllAsync()
            .Where(person=>person.PasportSeriaNumber == forCreationDto.PasportSeriaNumber)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (person is not null)
            throw new BodyBuildingLifeException(409, "Person is alredy exist");

        var mappedPersonData = _mapper.Map<Person>(forCreationDto);
        mappedPersonData.CreateAtt = DateTime.UtcNow;

        var responsePersonData = await _personRepository.CreateAsync(mappedPersonData);
        return  _mapper.Map<PersonForResultDto>(responsePersonData);

    }

    public async Task<bool> DeleteAsync(long personId)
    {
        var person = await _personRepository.RetriveAllAsync()
            .Where(person=>person.Id == personId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (person is null || person.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Person is not found");

        person.IsDeleted = true;
        var mappedPersonData = _mapper.Map<Person>(person);
        var responsePersonData = await _personRepository.UpdateAsync(mappedPersonData);
        
        if(responsePersonData.IsDeleted == true)
            return true;
        else
            return false;

    }

    public async Task<IEnumerable<PersonForResultDto>> RetrieveAllAsync()
    {
        var personData = await _personRepository.RetriveAllAsync()
            .Where(person=>person.IsDeleted==false)
            .Include(p=>p.PersonStandards).ThenInclude(p=>p.Standard)
            .Include(p=>p.PersonProteins).ThenInclude(p=>p.Protein)
            .Include(p=>p.PersonTrainers).ThenInclude(p=>p.Trainer)
            .Include(p=>p.PersonAssets)
            .AsNoTracking()
            .ToListAsync();

        return  _mapper.Map<IEnumerable<PersonForResultDto>>(personData);
       
    }

    public async Task<PersonForResultDto> RetruveByIdAsync(long id)
    {
        var personData = await _personRepository.RetriveAllAsync()
            .Where(person=>person.Id==id)
            .Include(p=>p.PersonStandards).ThenInclude(ps=>ps.Standard)
            .Include(p=>p.PersonProteins).ThenInclude (ps=>ps.Protein)
            .Include(p=>p.PersonAssets)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personData is null || personData.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Person is not found");
        return _mapper.Map<PersonForResultDto>(personData);

    }

    public async Task<PersonForResultDto> RtrieveByEmaiil(string email)
    {
        var person = await _personRepository.RetriveAllAsync()
            .Where(person => person.Email == email)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (person is null || person.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Person is not found");

        var mapperdPerson = _mapper.Map<PersonForResultDto>(person);
        return mapperdPerson;
    }

    public async Task<PersonForResultDto> UpdateAsync(PersonForUpdateDto forUpdateDto)
    {
        var personData = await _personRepository.RetriveAllAsync()
            .Where(person=>person.Id==forUpdateDto.Id)
            .Include (p=>p.PersonAssets)
            .Include(p=>p.PersonProteins)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personData is null || personData.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Person is not found");

        var mappedPersonData = _mapper.Map<Person>(personData);
        mappedPersonData.UpdateAtt = DateTime.UtcNow;
        var resulPersonData = await _personRepository.UpdateAsync(mappedPersonData);

        return _mapper.Map<PersonForResultDto>(resulPersonData);
        
    }
}
