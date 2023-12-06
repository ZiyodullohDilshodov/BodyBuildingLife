using BodyBuildingLife.Domain.Commons;
using BodyBuildingLife.Domain.Entities.Persons;
using BodyBuildingLife.Domain.Entities.Standards;

namespace BodyBuildingLife.Domain.Entities.PersonStandards;

public  class PersonStandard : Auditable
{
    public long PersonId { get; set; }
    public Person Person { get; set; }

    public long StandardID { get; set; }
    public Standard Standard { get; set; }
}
