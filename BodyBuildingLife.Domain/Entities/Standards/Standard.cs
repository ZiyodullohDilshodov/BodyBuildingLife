using BodyBuildingLife.Domain.Commons;

namespace BodyBuildingLife.Domain.Entities.Standards;

public  class Standard : Auditable
{
    public string Description { get; set; }
    public string ConsumptionTimes { get; set; }
    public string ConsumptionVolume { get; set; }

}
