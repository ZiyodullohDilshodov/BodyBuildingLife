using BodyBuildingLife.Domain.Commons;
using BodyBuildingLife.Domain.Entities.Assets;
using BodyBuildingLife.Domain.Entities.Cards;
using BodyBuildingLife.Domain.Entities.Protains;
using BodyBuildingLife.Domain.Entities.Standards;

namespace BodyBuildingLife.Domain.Entities.Persons;

public class Person : Auditable
{
    public string  Phone { get; set; }
    public string LastName { get; set; }
    public string  FirstName { get; set; }
    public long SportsCardId { get; set; }
    public string  PasportSeriaNumber { get; set; }

    public ICollection<Card> Cards { get; set; }
    public ICollection<Protein> Proteins { get; set; }
    public ICollection<PersonAsset> PersonAssets { get; set; }
    public ICollection<ProteinStandards> ProteinStandards { get; set; }
}
