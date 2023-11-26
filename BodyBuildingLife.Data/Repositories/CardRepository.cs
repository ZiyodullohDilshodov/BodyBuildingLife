using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.Cards;
using Microsoft.EntityFrameworkCore;

namespace BodyBuildingLife.Data.Repositories;

public class CardRepository : Repository<Card>, ICardRepository
{
    public CardRepository(AppDbContext appDbContext, DbSet<Card> dbSet) : base(appDbContext, dbSet)
    {
    }
}
