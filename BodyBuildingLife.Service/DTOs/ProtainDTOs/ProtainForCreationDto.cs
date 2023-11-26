namespace BodyBuildingLife.Service.DTOs.ProtainDTOs;

public  class ProtainForCreationDto
{
    public string Name { get; set; }
    public long volume { get; set; }
    public string Country { get; set; }
    public string Description { get; set; }
    public DateTime CreateAtt { get; set; }
    public DateTime UpdateAtt { get; set; }
    public string ValidityPeriod { get; set; }

}
