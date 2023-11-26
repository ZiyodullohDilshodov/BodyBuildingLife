using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.Persons;
using Microsoft.EntityFrameworkCore;

namespace BodyBuildingLife.Data.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(AppDbContext appDbContext, DbSet<Person> dbSet) : base(appDbContext, dbSet)
    {
    }
}
