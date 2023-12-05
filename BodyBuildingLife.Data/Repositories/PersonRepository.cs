using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.Persons;
using Microsoft.EntityFrameworkCore;

namespace BodyBuildingLife.Data.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    private readonly DbSet<Person>  _dbSet;
    private readonly AppDbContext _appDbContext;
    public PersonRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
        _dbSet = _appDbContext.Set<Person>();

    }

    public async  Task<Person> AddProteinInPerson(Person person)
    {
        var data = _dbSet.Update(person);
        await _appDbContext.SaveChangesAsync();

        return data.Entity;
    }
}
