using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.Protains;
using Microsoft.EntityFrameworkCore;

namespace BodyBuildingLife.Data.Repositories;

public class ProteinRepository : Repository<Protein>, IProteinRepository
{
    public ProteinRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
