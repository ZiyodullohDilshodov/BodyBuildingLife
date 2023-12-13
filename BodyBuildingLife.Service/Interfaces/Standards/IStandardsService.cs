using BodyBuildingLife.Service.DTOs.Standards;

namespace BodyBuildingLife.Service.Interfaces.Standards;

public  interface IStandardsService
{
    public Task<bool> DeleteAsync(long id);
    public Task<StandardForResultDto>GetByIdAsync(long id);
    public Task<IEnumerable<StandardForResultDto>> GetAllAsync();
    public Task<StandardForResultDto>UpdateAsync(StandardForUpdateDto standardForUpdateDto);
    public Task<StandardForResultDto> CreateAsync(StandardForCreationDto standardForCreationDto);
}
