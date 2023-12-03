using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.ProtainPersons;

namespace BodyBuildingLife.Data.Repositories;

public class PersonProteinRepository : Repository<PersonProtein>, IPersonProteinRepository
{
    public PersonProteinRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
