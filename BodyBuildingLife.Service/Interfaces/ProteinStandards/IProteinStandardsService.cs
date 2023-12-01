using BodyBuildingLife.Domain.Entities.Standards;

namespace BodyBuildingLife.Service.Interfaces;

public  interface IProteinStandardsService
{

    public Task<bool> DeleteAsync(long personID , long proteinID, long ProtainStandardsID);
    public Task<IEnumerable<ProteinStandards>> RetrieveAllAsync();
    public Task<ProteinStandards>RetrieveByIdAsync(long personID, long proteinID, long ProtainStandardsID);
    public Task<ProteinStandards>CreateAsync(long personID, long proteinID, long ProtainStandardsID);
    public Task<ProteinStandards> UpdateAsync(long personID, long proteinID, long ProtainStandardsID);
}
