using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Service.Exceptions;
using BodyBuildingLife.Domain.Entities.Protains;
using BodyBuildingLife.Service.DTOs.ProtainDTOs;
using BodyBuildingLife.Service.Interfaces.Protain;

namespace BodyBuildingLife.Service.Services;

public class ProtainService : IProtainService
{
    private readonly IMapper _mapper;
    private readonly IProtainRepository _protainRepository;

    public ProtainService(IMapper mapper, IProtainRepository protainRepository)
    {
        _mapper = mapper;
        _protainRepository = protainRepository;
    }

    public async Task<ProtainForResultDto> CreateAsync(ProtainForCreationDto forCreationDto)
    {
        var protain = await _protainRepository.RetriveAllAsync()
            .Where(protain=>protain.Name == forCreationDto.Name)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (protain is not null)
            throw new BodyBuildingLifeException(409, "Protain  already exists");

        var mappedProtain = _mapper.Map<Protain>(protain);
        var createProtain = await _protainRepository.CreateAsync(mappedProtain);

        return _mapper.Map<ProtainForResultDto>(createProtain);

    }

    public async Task<bool> DeleteAsync(long protainId)
    {
        var protain = await _protainRepository.RetriveAllAsync()
            .Where(pr => pr.Id == protainId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (protain is null)
            throw new BodyBuildingLifeException(404, "Protain is not found");

        return await  _protainRepository.DeleteAsync(protainId);
    }

    public async Task<IEnumerable<ProtainForResultDto>> RetrieveAllAsync()
    {
        var protains =  _protainRepository.RetriveAllAsync();
        return _mapper.Map<IEnumerable<ProtainForResultDto>>(protains);
        
    }

    public async Task<ProtainForResultDto> RetruveByIdAsync(long id)
    {
        var protain = await _protainRepository.RetriveAllAsync()
            .Where(p=>p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (protain is null)
            throw new BodyBuildingLifeException(404, "Protain is not found");

        return _mapper.Map<ProtainForResultDto>(protain);
    }

    public async Task<ProtainForResultDto> UpdateAsync(ProtainForUpdateDto forUpdateDto)
    {
        var protain = await _protainRepository.RetriveAllAsync()
            .Where(p => p.Id == forUpdateDto.Id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (protain is null)
            throw new BodyBuildingLifeException(404, "Protain is not found");

        var mappedProtain = _mapper.Map<Protain>(protain);
        var updateProtain = await _protainRepository.UpdateAsync(mappedProtain);

        return _mapper.Map<ProtainForResultDto>(updateProtain);
        
    }
}
