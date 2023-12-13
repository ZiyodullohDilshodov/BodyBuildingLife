using BodyBuildingLife.Service.DTOs.Standards;

namespace BodyBuildingLife.Service.Interfaces.PersonStandards;

public  interface IPersonStandardsService
{
    public Task<bool> DeleteAsync(long id);
    public Task<PersonStandardForResultDto>GetByIdAsync(long id);
    public Task<IEnumerable<PersonStandardForResultDto>> GetAllAsync();
    public Task<PersonStandardForResultDto> UpdateAsync(PersonStandardForUpdateDto personStandardForUpdateDto);
    public Task<PersonStandardForResultDto> CreateAsync(PersonStandardForCreationDto personStandardForCreationDto);

}
