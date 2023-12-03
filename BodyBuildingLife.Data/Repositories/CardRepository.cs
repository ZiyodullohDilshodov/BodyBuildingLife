using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.Cards;

namespace BodyBuildingLife.Data.Repositories;

public class CardRepository : Repository<Card>, ICardRepository
{
    public CardRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
