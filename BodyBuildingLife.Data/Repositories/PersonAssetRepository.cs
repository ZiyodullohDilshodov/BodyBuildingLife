using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.Assets;

namespace BodyBuildingLife.Data.Repositories;

public class PersonAssetRepository : Repository<PersonAsset>, IPersonAssetRepository
{
    public PersonAssetRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
