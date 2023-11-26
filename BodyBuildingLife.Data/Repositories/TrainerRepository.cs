using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.Trainers;
using Microsoft.EntityFrameworkCore;

namespace BodyBuildingLife.Data.Repositories;

public class TrainerRepository : Repository<Trainer>, ITrainerRepository
{
    public TrainerRepository(AppDbContext appDbContext, DbSet<Trainer> dbSet) : base(appDbContext, dbSet)
    {
    }
}
