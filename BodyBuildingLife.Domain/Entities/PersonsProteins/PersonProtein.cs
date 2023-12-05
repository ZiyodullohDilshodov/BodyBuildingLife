using BodyBuildingLife.Domain.Commons;
using BodyBuildingLife.Domain.Entities.Persons;
using BodyBuildingLife.Domain.Entities.Protains;

namespace BodyBuildingLife.Domain.Entities.ProtainPersons;

public class PersonProtein : Auditable
{
    public long ProteinId { get; set; }
    public Protein Protein { get; set; }

    public long PersonId { get; set; }
    public Person Person { get; set; }


}
