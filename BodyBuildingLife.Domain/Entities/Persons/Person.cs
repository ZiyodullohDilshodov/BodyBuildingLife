using BodyBuildingLife.Domain.Commons;

namespace BodyBuildingLife.Domain.Entities.Persons;

public class Person : Auditable
{
    public string  Phone { get; set; }
    public string LastName { get; set; }
    public string  FirstName { get; set; }
    public long SportsCardId { get; set; }
    public string  PasportSeriaNumber { get; set; }

}
