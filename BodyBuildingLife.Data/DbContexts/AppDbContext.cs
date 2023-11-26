using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Domain.Entities.Cards;
using BodyBuildingLife.Domain.Entities.Assets;
using BodyBuildingLife.Domain.Entities.Persons;
using BodyBuildingLife.Domain.Entities.Protains;
using BodyBuildingLife.Domain.Entities.Trainers;
using BodyBuildingLife.Domain.Entities.ProtainPersons;
using BodyBuildingLife.Domain.Entities.PersonTreainers;

namespace BodyBuildingLife.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Person> Persons { get; set; }

    public DbSet<Trainer> Trainers { get; set; }

    public DbSet<Protain> Protains { get; set; }
    
    public DbSet<Card> Cards { get; set; }
    
    public DbSet<PersonTrainer> PersonTrainers { get;set; }
    
    public DbSet<PersonProtain> PersonProtains { get; set; }
    
    public DbSet<PersonAsset> PersonAssets { get; set; }
    
    public DbSet<TrainerAsset> PersonTrainersAsset { get; set; }

}
