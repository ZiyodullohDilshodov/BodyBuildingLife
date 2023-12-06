using BodyBuildingLife.Domain.Commons;
using BodyBuildingLife.Domain.Entities.Assets;
using BodyBuildingLife.Domain.Entities.Standards;
using BodyBuildingLife.Domain.Entities.ProtainPersons;
using BodyBuildingLife.Domain.Entities.PersonStandards;
using BodyBuildingLife.Domain.Entities.PersonTreainers;

namespace BodyBuildingLife.Domain.Entities.Persons;

public class Person : Auditable
{
    public string  Phone { get; set; }
    public string LastName { get; set; }
    public string  FirstName { get; set; }
    public long ProteinId { get; set; }
    public long SportsCardId { get; set; }
    public string  PasportSeriaNumber { get; set; }

    public ICollection<PersonProtein> PersonProteins { get; set; }
    public ICollection<PersonAsset> PersonAssets { get; set; }
    public ICollection<PersonStandard> PersonStandards { get; set; }
    public ICollection<PersonTrainer> PersonTrainers { get ; set; }
}
