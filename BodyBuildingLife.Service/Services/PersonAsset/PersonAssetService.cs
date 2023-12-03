using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Service.Helpers;
using BodyBuildingLife.Service.Exceptions;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.Assets;
using BodyBuildingLife.Service.DTOs.PersonAsset;
using BodyBuildingLife.Service.Interfaces.IPersonAsset;

namespace BodyBuildingLife.Service.Services;

public class PersonAssetService : IPersonAssetService
{

    private readonly IMapper _mapper;
    private readonly IPersonRepository _personRepository;
    private readonly IPersonAssetRepository _personAssetRepository;

    public PersonAssetService(IMapper mapper,
                              IPersonRepository personRepository, 
                              IPersonAssetRepository personAssetRepository)
    {
        _mapper = mapper;
        _personRepository = personRepository;
        _personAssetRepository = personAssetRepository;
    }

    public async Task<PersonAssetForResultDto> CreateAsync(long userId, IFormFile formFile)
    {
        var person = await _personRepository.RetriveAllAsync()
            .Where(p => p.Id == userId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (person is null || person.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Person is not found");

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(formFile.FileName);
        var rootPath = Path.Combine(WebHostEnvarement.WebRootPath, "Media", "Persons", "PersonImmage", fileName);

        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        var mappedAsset = new PersonAsset()
        {
            PersonId =  userId,
            Name = formFile.Name,
            Size = formFile.Length,
            Type = formFile.ContentType,
            CreateAtt = DateTime.UtcNow,
            Extension = Path.GetExtension(formFile.FileName),
            Path = Path.Combine("Media", "Persons", "PersonImmage", formFile.FileName)
        };

        var result = await _personAssetRepository.CreateAsync(mappedAsset);

        return _mapper.Map<PersonAssetForResultDto>(result);

    }

    public async Task<bool> RemoveAsync(long personId, long id)
    {
        var person = await _personRepository.RetriveAllAsync()
            .Where(p=>p.Id== personId)
            .FirstOrDefaultAsync();

        if (person is null || person.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Person is not found");
    
        var personAsset = await _personAssetRepository.RetriveAllAsync()
            .Where(pa=>pa.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personAsset is null)
            throw new BodyBuildingLifeException(404, "Asset is not found");

        return await _personAssetRepository.DeleteAsync(personAsset.Id);
    }

    public async Task<IEnumerable<PersonAssetForResultDto>> RetrieveAllAsync(long userId)
    {
        var personAssets = await _personRepository.RetriveAllAsync()
            .Where(p=>p.Id== userId)
            .Include(p=>p.PersonAssets)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personAssets is null || personAssets.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Person is not found");

        return   _mapper.Map<IEnumerable<PersonAssetForResultDto>>(personAssets);
    }

    public async Task<PersonAssetForResultDto> RetrieveByIdAsync(long personId, long id)
    {
        var person = await _personRepository.RetriveAllAsync()
            .Where(p => p.Id == personId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (person is null || person.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Person is not found");

        var personAsset = await _personAssetRepository.RetriveAllAsync()
            .Where(pa=>pa.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personAsset is null)
            throw new BodyBuildingLifeException(404, "Asset is not found");

        return _mapper.Map<PersonAssetForResultDto>(personAsset);

    }
}
