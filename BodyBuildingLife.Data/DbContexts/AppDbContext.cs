using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Domain.Entities.Cards;
using BodyBuildingLife.Domain.Entities.Assets;
using BodyBuildingLife.Domain.Entities.Persons;
using BodyBuildingLife.Domain.Entities.Protains;
using BodyBuildingLife.Domain.Entities.Trainers;
using BodyBuildingLife.Domain.Entities.ProtainPersons;
using BodyBuildingLife.Domain.Entities.PersonTreainers;
using BodyBuildingLife.Domain.Entities.Standards;

namespace BodyBuildingLife.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Card> Cards { get; set; }
    public DbSet<Person> Persons { get; set; }

    public DbSet<Trainer> Trainers { get; set; }

    public DbSet<Protein> Proteins { get; set; }
    
    public DbSet<PersonAsset> PersonAssets { get; set; }
    
    public DbSet<PersonTrainer> PersonTrainers { get;set; }
    
    public DbSet<PersonProtein> PersonProteins { get; set; }
    
    public DbSet<TrainerAsset> PersonTrainersAsset { get; set; }
    public DbSet<ProteinStandards> ProteinStandards { get; set; }

}
