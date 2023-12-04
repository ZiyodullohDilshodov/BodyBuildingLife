using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.Persons;

namespace BodyBuildingLife.Data.Repositories;

public class PersonRepository : Repository<Person>, IPersonService
{
    public PersonRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
