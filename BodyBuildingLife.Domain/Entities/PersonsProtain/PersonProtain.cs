using BodyBuildingLife.Domain.Commons;
using BodyBuildingLife.Domain.Entities.Persons;
using BodyBuildingLife.Domain.Entities.Protains;

namespace BodyBuildingLife.Domain.Entities.ProtainPersons;

public class PersonProtain : Auditable
{
    public long ProtainId { get; set; }
    public Protain Protain { get; set; }

    public long PersonId { get; set; }
    public Person Person { get; set; }
}
