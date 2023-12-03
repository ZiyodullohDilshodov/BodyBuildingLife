using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.Assets;
using Microsoft.EntityFrameworkCore;

namespace BodyBuildingLife.Data.Repositories;

public class TrainerAssetRepository : Repository<TrainerAsset>, ITrainerAssetRepository
{
    public TrainerAssetRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
