using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Service.Exceptions;
using BodyBuildingLife.Domain.Entities.Protains;
using BodyBuildingLife.Service.DTOs.ProtainDTOs;
using BodyBuildingLife.Service.Interfaces.Protain;

namespace BodyBuildingLife.Service.Services;

public class ProteinService : IProteinService
{
    private readonly IMapper _mapper;
    private readonly IProteinRepository _proteinRepository;

    public ProteinService(IMapper mapper, IProteinRepository proteinRepository)
    {
        _mapper = mapper;
        _proteinRepository = proteinRepository;
    }

    public async Task<ProteinForResultDto> CreateAsync(ProteinForCreationDto forCreationDto)
    {
        var protein = await _proteinRepository.RetriveAllAsync()
            .Where(protein=>protein.Name == forCreationDto.Name)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (protein is not null)
            throw new BodyBuildingLifeException(409, "Protain  already exists");

        var mappedProtein = _mapper.Map<Protein>(forCreationDto);
        mappedProtein.CreateAtt = DateTime.UtcNow;
        var createProtein = await _proteinRepository.CreateAsync(mappedProtein);

        return _mapper.Map<ProteinForResultDto>(createProtein);

    }

    public async Task<bool> DeleteAsync(long proteinId)
    {
        var protein = await _proteinRepository.RetriveAllAsync()
            .Where(pr => pr.Id == proteinId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (protein is null)
            throw new BodyBuildingLifeException(404, "Protain is not found");

        return await  _proteinRepository.DeleteAsync(proteinId);
    }

    public async Task<IEnumerable<ProteinForResultDto>> RetrieveAllAsync()
    {
        var proteins =  _proteinRepository.RetriveAllAsync();
        return _mapper.Map<IEnumerable<ProteinForResultDto>>(proteins);
        
    }

    public async Task<ProteinForResultDto> RetruveByIdAsync(long id)
    {
        var protein = await _proteinRepository.RetriveAllAsync()
            .Where(p=>p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (protein is null)
            throw new BodyBuildingLifeException(404, "Protain is not found");

        return _mapper.Map<ProteinForResultDto>(protein);
    }

    public async Task<ProteinForResultDto> UpdateAsync(ProteinForUpdateDto forUpdateDto)
    {
        var protain = await _proteinRepository.RetriveAllAsync()
            .Where(p => p.Id == forUpdateDto.Id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (protain is null)
            throw new BodyBuildingLifeException(404, "Protain is not found");

        var mappedProtein = _mapper.Map<Protein>(forUpdateDto);
        mappedProtein.UpdateAtt = DateTime.UtcNow;
        var updateProtein = await _proteinRepository.UpdateAsync(mappedProtein);

        return _mapper.Map<ProteinForResultDto>(updateProtein);
        
    }
}
