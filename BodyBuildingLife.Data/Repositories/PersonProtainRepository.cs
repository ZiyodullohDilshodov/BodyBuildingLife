using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.ProtainPersons;

namespace BodyBuildingLife.Data.Repositories;

public class PersonProtainRepository : Repository<PersonProtain>, IPersonProtainRepository
{
    public PersonProtainRepository(AppDbContext appDbContext, DbSet<PersonProtain> dbSet) : base(appDbContext, dbSet)
    {
    }
}
