using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Service.Interfaces;
using BodyBuildingLife.Service.Exceptions;
using BodyBuildingLife.Service.DTOs.Standards;
using BodyBuildingLife.Domain.Entities.Standards;

namespace BodyBuildingLife.Service.Services;

public class ProteinStandardsService : IProteinStandardsService
{
    private readonly  IMapper _mapper;
    private readonly  IProteinRepository _proteinRepository;
    private readonly  IPersonRepository _personRepository;
    private readonly  IProteinStandardsRepository _proteinStandardsRepository;

    public ProteinStandardsService(IMapper mapper,
                                   IPersonRepository personRepository,
                                   IProteinRepository proteinRepository,
                                   IProteinStandardsRepository proteinStandardsRepository)
    {
        _personRepository = personRepository;
        _proteinRepository = proteinRepository;
        _proteinStandardsRepository = proteinStandardsRepository;
    }

    public async Task<ProteinStandardsForResultDto> CreateAsync(long personID, long proteinID, ProteinStandardsForResultDto proteinStandardsForResultDto)
    {
        var person = await _personRepository.RetriveAllAsync()
           .Where(p => p.Id == personID)
           .AsNoTracking()
           .FirstOrDefaultAsync();

        if (person is null)
            throw new BodyBuildingLifeException(404, "Person is noy found");

        var protein = await _proteinRepository.RetriveAllAsync()
            .Where(p => p.Id == proteinID)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (protein is null)
            throw new BodyBuildingLifeException(404, "Protein is not found");

        var mapped = _mapper.Map<ProteinStandards>(proteinStandardsForResultDto);
        var createPersonStandards = await  _proteinStandardsRepository.CreateAsync(mapped);
        return _mapper.Map<ProteinStandardsForResultDto>(createPersonStandards);
    }

    public async Task<bool> DeleteAsync(long personID, long proteinID, long protainStandardsId)
    {
        var person = await _personRepository.RetriveAllAsync()
          .Where(p => p.Id == personID)
          .AsNoTracking()
          .FirstOrDefaultAsync();

        if (person is null)
            throw new BodyBuildingLifeException(404, "Person is noy found");

        var protein = await _proteinRepository.RetriveAllAsync()
            .Where(p => p.Id == proteinID)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (protein is null)
            throw new BodyBuildingLifeException(404, "Protein is not found");

        var proteinStandart = await _proteinStandardsRepository.RetriveAllAsync()
            .Where(ps => ps.Id == protainStandardsId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (proteinStandart is null)
            throw new BodyBuildingLifeException(404, "ProteinStandards is not found");

        return await _proteinStandardsRepository.DeleteAsync(protainStandardsId);
        
    }

    public async Task<IEnumerable<ProteinStandardsForResultDto>> RetrieveAllAsync()
    {
        var ProteinStandards = await _proteinStandardsRepository.RetriveAllAsync()
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return _mapper.Map<IEnumerable<ProteinStandardsForResultDto>>(ProteinStandards);
    }
    

    public async Task<ProteinStandardsForResultDto> RetrieveByIdAsync(long personID, long proteinID, long proteinStandardsId)
    {
        var person = await _personRepository.RetriveAllAsync()
          .Where(p => p.Id == personID)
          .Include(ps => ps.Proteins.Where(p=>p.Id == proteinID))
          .Include(ps=>ps.Proteins.Where(p=>p.ProteinStandardsId == proteinStandardsId))
          .AsNoTracking()
          .FirstOrDefaultAsync();

        if (person is null || person.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Person is noy found");

        var protein = await _proteinRepository.RetriveAllAsync()
            .Where(p => p.Id == proteinID)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (protein is null)
            throw new BodyBuildingLifeException(404, "Protein is not found");

        var proteinStandart = await _proteinStandardsRepository.RetriveAllAsync()
            .Where(ps => ps.Id == proteinStandardsId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (proteinStandart is null)
            throw new BodyBuildingLifeException(404, "ProteinStandards is not found");

        var mapped = _mapper.Map<ProteinStandardsForResultDto>(person);
        return mapped;
    }

    public async Task<ProteinStandardsForResultDto> UpdateAsync(long personID, long proteinID, ProteinStandardsForResultDto proteinStandardsForResultDto)
    {

        var person = await _personRepository.RetriveAllAsync()
         .Where(p => p.Id == personID)
         .AsNoTracking()
         .FirstOrDefaultAsync();

        if (person is null || person.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Person is noy found");

        var protein = await _proteinRepository.RetriveAllAsync()
            .Where(p => p.Id == proteinID)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (protein is null)
            throw new BodyBuildingLifeException(404, "Protein is not found");

        var proteinStandart = await _proteinStandardsRepository.RetriveAllAsync()
            .Where(ps => ps.Id == proteinStandardsForResultDto.Id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (proteinStandart is null)
            throw new BodyBuildingLifeException(404, "ProteinStandards is not found");

        var mapped = _mapper.Map<ProteinStandards>(proteinStandardsForResultDto);
        var updateProteinStandards = await _proteinStandardsRepository.UpdateAsync(mapped);
        return _mapper.Map<ProteinStandardsForResultDto>(updateProteinStandards);
    }
}
