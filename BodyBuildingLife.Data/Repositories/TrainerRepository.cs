using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.Trainers;

namespace BodyBuildingLife.Data.Repositories;

public class TrainerRepository : Repository<Trainer>, ITrainerRepository
{
    public TrainerRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
