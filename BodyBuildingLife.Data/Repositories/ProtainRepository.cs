using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.Protains;
using Microsoft.EntityFrameworkCore;

namespace BodyBuildingLife.Data.Repositories;

public class ProtainRepository : Repository<Protain>, IProtainRepository
{
    public ProtainRepository(AppDbContext appDbContext, DbSet<Protain> dbSet) : base(appDbContext, dbSet)
    {
    }
}
