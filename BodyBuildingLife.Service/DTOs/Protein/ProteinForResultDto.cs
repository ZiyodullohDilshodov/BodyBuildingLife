using BodyBuildingLife.Service.DTOs.Standards;

namespace BodyBuildingLife.Service.DTOs.ProtainDTOs;

public  class ProtainForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long volume { get; set; }
    public string Country { get; set; }
    public string Description { get; set; }
    public DateTime CreateAtt { get; set; }
    public DateTime UpdateAtt { get; set; }
    public string ValidityPeriod { get; set; }

    public ICollection<ProteinStandardsForResultDto> ProteinStandards { get; set; }
}
