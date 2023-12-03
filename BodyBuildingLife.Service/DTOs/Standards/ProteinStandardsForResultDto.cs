namespace BodyBuildingLife.Service.DTOs.Standards;

public  class ProteinStandardsForResultDto
{
    public long Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreateAtt { get; set; }
    public DateTime UpdateAtt { get; set; }
    public string Description { get; set; }
    public string ConsumptionTimes { get; set; }
    public string ConsumptionVolume { get; set; }

}
