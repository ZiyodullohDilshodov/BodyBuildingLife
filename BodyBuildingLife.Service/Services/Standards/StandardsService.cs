using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Service.Exceptions;
using BodyBuildingLife.Service.DTOs.Standards;
using BodyBuildingLife.Domain.Entities.Standards;
using BodyBuildingLife.Service.Interfaces.Standards;

namespace BodyBuildingLife.Service.Services.Standards
{
    public class StandardsService : IStandardsService
    {
        private readonly IMapper _mapper;
        private readonly IStandardsRepository _standardRepository;

        public StandardsService(IMapper mapper,IStandardsRepository standardsRepository)
        {
            _mapper = mapper;
            _standardRepository = standardsRepository;
        }

        public async Task<StandardForResultDto> CreateAsync(StandardForCreationDto standardForCreationDto)
        {
            var standards = await _standardRepository.RetriveAllAsync()
                .Where(s=>s.ProteinName == standardForCreationDto.ProteinName)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (standards is not null)
                throw new BodyBuildingLifeException(409, "Standard is already exists");

            var mapped = _mapper.Map<Standard>(standardForCreationDto);
            mapped.CreateAtt = DateTime.UtcNow;
            var createStandard = await _standardRepository.CreateAsync(mapped);
            return _mapper.Map<StandardForResultDto>(createStandard);
            
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var standard = await _standardRepository.RetriveAllAsync()
                .Where(s=>s.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (standard is null)
                throw new BodyBuildingLifeException(409, "Standards is not found");

            return  await _standardRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<StandardForResultDto>> GetAllAsync()
        {
            var standards = await _standardRepository.RetriveAllAsync()
                .AsNoTracking()
                .ToListAsync();
            
            return _mapper.Map<IEnumerable<StandardForResultDto>>(standards);
        }

        public async Task<StandardForResultDto> GetByIdAsync(long id)
        {
            var standards = await _standardRepository.RetriveAllAsync()
                .Where(s => s.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (standards is null)
                throw new BodyBuildingLifeException(404, "Standard is not found");

            return _mapper.Map<StandardForResultDto>(standards);
        }

        public async Task<StandardForResultDto> UpdateAsync(StandardForUpdateDto standardForUpdateDto)
        {
            var standard = await _standardRepository.RetriveAllAsync()
                .Where(s => s.Id == standardForUpdateDto.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (standard is null)
                throw new BodyBuildingLifeException(404, "Standards is not found");

            var mapped = _mapper.Map<Standard>(standardForUpdateDto);
            mapped.UpdateAtt = DateTime.UtcNow;
            var updateStandard = await _standardRepository.UpdateAsync(mapped);
            return _mapper.Map<StandardForResultDto>(updateStandard);
        }
    }
}
