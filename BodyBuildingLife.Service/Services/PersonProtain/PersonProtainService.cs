using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Service.Exceptions;
using BodyBuildingLife.Domain.Entities.ProtainPersons;
using BodyBuildingLife.Service.DTOs.PersonProtainDTOs;
using BodyBuildingLife.Service.Interfaces.PersonProtain;

namespace BodyBuildingLife.Service.Services;

public class PersonProtainService : IPersonProtainService
{
    private readonly IMapper _mapper;
    private readonly IPersonRepository _personRepository;
    private readonly IProtainRepository _protainRepository;
    private readonly IPersonProtainRepository _personProtainRepository;



    public PersonProtainService(IMapper mapper,
                                IPersonRepository personRepository, 
                                IProtainRepository protainRepository)
    {
        _mapper = mapper;
        _personRepository = personRepository;
        _protainRepository = protainRepository;
    }

    public async Task<PersonProtainForResultDto> CreateAsync(PersonProtainForCreationDto forCreationDto)
    {
        var personData = await _personRepository.RetriveAllAsync()
            .Where(person=>person.Id == forCreationDto.PersonID)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personData is null || personData.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Person is not found");

        var protainData = await _protainRepository.RetriveAllAsync()
            .Where(protain=>protain.Id == forCreationDto.ProtainID)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (protainData is null || protainData.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Protain is not found");


        var selection = await _personProtainRepository.RetriveAllAsync().ToListAsync();
        foreach(var item in selection)
        {
            if (item.PersonId == forCreationDto.PersonID && item.ProtainId == forCreationDto.ProtainID)
                throw new BodyBuildingLifeException(404, "PersonProtain alrwady exists");
                
        }    


        var mappedData = _mapper.Map<PersonProtain>(forCreationDto);
        mappedData.CreateAtt = DateTime.UtcNow;
        var response = await _personProtainRepository.CreateAsync(mappedData);
        return _mapper.Map<PersonProtainForResultDto>(response);

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

    public async Task<IEnumerable<PersonProtainForResultDto>> RetrieveAllAsync()
    {
        var personProtain = await  _personProtainRepository.RetriveAllAsync()
            .Include(p=>p.Person)
            .Include(p=>p.Protain)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<PersonProtainForResultDto>>(personProtain);
    }

    public async Task<PersonProtainForResultDto> RetruveByIdAsync(long id)
    {
        var personProtain = await _personProtainRepository.RetriveAllAsync()
            .Where (pp => pp.Id == id)
            .Include(p=>p.Person)
            .Include(p=>p.Protain)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personProtain is null)
            throw new BodyBuildingLifeException(404, "PersonProtain is not found");

        return _mapper.Map<PersonProtainForResultDto>(personProtain);
    }

    public async Task<PersonProtainForResultDto> UpdateAsync(PersonProtainForUpdateDto forUpdateDto)
    {
        var personProtain = await _personProtainRepository.RetriveAllAsync()
            .Where(pp=>pp.Id == forUpdateDto.Id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personProtain is null)
            throw new BodyBuildingLifeException(404, "PersonProtain is not found");

        var selctionPerson = await _personProtainRepository.RetriveAllAsync()
            .Where(p => p.Id == forUpdateDto.PersonID)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (selctionPerson is null || selctionPerson.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Person is not found");

        var selectionProtain = await _protainRepository.RetriveAllAsync()
            .Where(p => p.Id == forUpdateDto.ProtainID)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (selectionProtain is null || selectionProtain.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Protain is not found");

        var mappedData = _mapper.Map<PersonProtain>(forUpdateDto);
        mappedData.UpdateAtt = DateTime.UtcNow;
        var responseData = _personProtainRepository.UpdateAsync(mappedData);

        return _mapper.Map<PersonProtainForResultDto>(responseData);

    }
}
