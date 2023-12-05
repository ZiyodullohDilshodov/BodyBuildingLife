using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Service.Exceptions;
using BodyBuildingLife.Domain.Entities.ProtainPersons;
using BodyBuildingLife.Service.DTOs.PersonProtainDTOs;
using BodyBuildingLife.Service.Interfaces.PersonProtain;
using BodyBuildingLife.Domain.Entities.Persons;

namespace BodyBuildingLife.Service.Services;

public class PersonProteinService : IPersonProteinService
{
    private readonly IMapper _mapper;
    private readonly IPersonRepository _personRepository;
    private readonly IProteinRepository _protainRepository;
    private readonly IPersonProteinRepository _personProtainRepository;



    public PersonProteinService(IMapper mapper,
                                IPersonRepository personRepository, 
                                IProteinRepository protainRepository,
                                IPersonProteinRepository personProteinRepository)
    {
        _mapper = mapper;
        _personRepository = personRepository;
        _protainRepository = protainRepository;
        _personProtainRepository = personProteinRepository;
    }

    public async Task<PersonProteinForResultDto> CreateAsync(PersonProteinForCreationDto forCreationDto)
    {
        var personData = await _personRepository.RetriveAllAsync()
            .Where(person=>person.Id == forCreationDto.PersonID)
            .Include(p=>p.Proteins)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personData is null || personData.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Person is not found");

        var protainData = await _protainRepository.RetriveAllAsync()
            .Where(protain=>protain.Id == forCreationDto.ProteinID)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (protainData is null || protainData.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Protain is not found");


        var selection = await _personProtainRepository.RetriveAllAsync().ToListAsync();

        foreach (var item in selection)
        {
            if (item.PersonId == forCreationDto.PersonID && item.ProteinId == forCreationDto.ProteinID)
                throw new BodyBuildingLifeException(404, "PersonProtain alrwady exists");

        }

        personData.Proteins.Append(protainData);
        var mapped = _mapper.Map<Person>(personData);
        var  AddProteinInPerson = await _personRepository.AddProteinInPerson(mapped);

        var mappedData = _mapper.Map<PersonProtein>(forCreationDto);
        mappedData.CreateAtt = DateTime.UtcNow;
        var response = await _personProtainRepository.CreateAsync(mappedData);
        return _mapper.Map<PersonProteinForResultDto>(response);

    }

    public async Task<bool> DeleteAsync(long personProtainId)
    {
        var personProtain = await _personProtainRepository.RetriveAllAsync()
            .Where(pp => pp.Id == personProtainId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personProtain is null)
            throw new BodyBuildingLifeException(404, "PersonProtain is not found");

        return  await _personProtainRepository.DeleteAsync(personProtainId);
    }

    public async Task<IEnumerable<PersonProteinForResultDto>> RetrieveAllAsync()
    {
        var personProtain = await  _personProtainRepository.RetriveAllAsync()
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<PersonProteinForResultDto>>(personProtain);
    }

    public async Task<PersonProteinForResultDto> RetruveByIdAsync(long id)
    {
        var personProtain = await _personProtainRepository.RetriveAllAsync()
            .Where (pp => pp.Id == id)
            .Include(p=>p.Protein)
            .Include(p=>p.Person)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personProtain is null)
            throw new BodyBuildingLifeException(404, "PersonProtain is not found");

        return _mapper.Map<PersonProteinForResultDto>(personProtain);
    }

    public async Task<PersonProteinForResultDto> UpdateAsync(PersonProteinForUpdateDto forUpdateDto)
    {
        var personProtain = await _personProtainRepository.RetriveAllAsync()
            .Where(pp=>pp.Id == forUpdateDto.Id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personProtain is null)
            throw new BodyBuildingLifeException(404, "PersonProtain is not found");

        var selctionPerson = await _personRepository.RetriveAllAsync()
            .Where(p => p.Id == forUpdateDto.PersonID)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (selctionPerson is null || selctionPerson.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Person is not found");

        var selectionProtain = await _protainRepository.RetriveAllAsync()
            .Where(p => p.Id == forUpdateDto.ProteinID)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (selectionProtain is null || selectionProtain.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Protain is not found");

        var mappedData = _mapper.Map<PersonProtein>(forUpdateDto);
        mappedData.UpdateAtt = DateTime.UtcNow;
        var responseData =await  _personProtainRepository.UpdateAsync(mappedData);

        return _mapper.Map<PersonProteinForResultDto>(responseData);

    }
}
