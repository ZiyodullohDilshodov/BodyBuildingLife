using BodyBuildingLife.Service.Interfaces;

namespace BodyBuildingLife.Service.Services.ProteinStandards;

public class ProteinStandardsService : IProteinStandardsService
{
    //TO DO LOGIC
    public Task<Domain.Entities.Standards.ProteinStandards> CreateAsync(long personID, long proteinID, long ProtainStandardsID)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long personID, long proteinID, long ProtainStandardsID)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Entities.Standards.ProteinStandards>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Standards.ProteinStandards> RetrieveByIdAsync(long personID, long proteinID, long ProtainStandardsID)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Standards.ProteinStandards> UpdateAsync(long personID, long proteinID, long ProtainStandardsID)
    {
        throw new NotImplementedException();
    }
}
