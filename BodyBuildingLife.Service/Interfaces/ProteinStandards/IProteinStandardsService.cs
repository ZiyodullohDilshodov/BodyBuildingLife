using BodyBuildingLife.Domain.Entities.Standards;
using BodyBuildingLife.Service.DTOs.Standards;

namespace BodyBuildingLife.Service.Interfaces;

public  interface IProteinStandardsService
{

    public Task<bool> DeleteAsync(long personID , long proteinID, long ProtainStandardsID);
    public Task<IEnumerable<ProteinStandardsForResultDto>> RetrieveAllAsync();
    public Task<ProteinStandardsForResultDto> RetrieveByIdAsync(long personID, long proteinID, long ProtainStandardsID);
    public Task<ProteinStandardsForResultDto> CreateAsync(long personID, long proteinID, ProteinStandardsForResultDto proteinStandardsForResultDto);
    public Task<ProteinStandardsForResultDto> UpdateAsync(long personID, long proteinID, ProteinStandardsForResultDto proteinStandardsForResultDto);
}
