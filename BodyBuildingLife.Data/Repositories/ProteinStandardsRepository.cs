using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.Standards;

namespace BodyBuildingLife.Data.Repositories;

public class ProteinStandardsRepository : Repository<ProteinStandards>, IProteinStandardsRepository
{
    public ProteinStandardsRepository(AppDbContext appDbContext, DbSet<ProteinStandards> dbSet) : base(appDbContext, dbSet)
    {
    }
}
