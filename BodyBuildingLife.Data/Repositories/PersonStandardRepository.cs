using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.PersonStandards;

namespace BodyBuildingLife.Data.Repositories;

public class PersonStandardRepository : Repository<PersonStandard>, IPersonStandardRepository
{
    public PersonStandardRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
