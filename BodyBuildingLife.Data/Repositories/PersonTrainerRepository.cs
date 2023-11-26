using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.PersonTreainers;
using Microsoft.EntityFrameworkCore;

namespace BodyBuildingLife.Data.Repositories;

public class PersonTrainerRepository : Repository<PersonTrainer>, IPersonTrainerRepository
{
    public PersonTrainerRepository(AppDbContext appDbContext, DbSet<PersonTrainer> dbSet) : base(appDbContext, dbSet)
    {
    }
}
