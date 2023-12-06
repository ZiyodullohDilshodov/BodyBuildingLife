using BodyBuildingLife.Domain.Commons;
using BodyBuildingLife.Domain.Entities.Standards;

namespace BodyBuildingLife.Domain.Entities.Protains;

public class Protein : Auditable
{
    public string Name { get; set; }
    public long volume { get; set; }
    public string Country { get; set; }
    public string Description { get; set; }
    public string ValidityPeriod { get; set; }

}
    
