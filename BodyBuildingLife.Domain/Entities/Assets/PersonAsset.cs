using BodyBuildingLife.Domain.Entities.Persons;

namespace BodyBuildingLife.Domain.Entities.Assets;

public  class PersonAsset : Asset
{
    public long PersonId { get; set; }
    public Person Person { get; set; }
}
