using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.PersonTreainers;

namespace BodyBuildingLife.Data.Repositories;

public class PersonTrainerRepository : Repository<PersonTrainer>, IPersonTrainerRepository
{
    public PersonTrainerRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
