using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.Assets;
using Microsoft.EntityFrameworkCore;

namespace BodyBuildingLife.Data.Repositories;

public class PersonAssetRepository : Repository<PersonAsset>, IPersonAssetRepository
{
    public PersonAssetRepository(AppDbContext appDbContext, DbSet<PersonAsset> dbSet) : base(appDbContext, dbSet)
    {
    }
}
