using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.Standards;

namespace BodyBuildingLife.Data.Repositories;

public class StandardsRepository : Repository<Standard>, IStandardsRepository
{
    public StandardsRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
