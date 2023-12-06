using BodyBuildingLife.Domain.Entities.Standards;

namespace BodyBuildingLife.Service.DTOs.Standards;

public  class PersonStandardForResultDto
{
    public long Id { get; set; }
    public long PersonId { get; set; }
    public long StandardID { get; set; }
    public DateTime CreateAtt { get; set; }
    public DateTime UpdateAtt { get; set; }

}
