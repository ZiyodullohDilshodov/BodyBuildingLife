using BodyBuildingLife.Domain.Commons;
using BodyBuildingLife.Domain.Entities.Persons;
using BodyBuildingLife.Domain.Entities.Trainers;

namespace BodyBuildingLife.Domain.Entities.PersonTreainers;

public  class PersonTrainer : Auditable
{
    public long TraionerId { get; set; }
    public Trainer Trainer { get; set; }

    public long PersonId { get; set; }
    public Person Person { get; set; }
}
