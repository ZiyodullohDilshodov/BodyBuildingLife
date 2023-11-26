namespace BodyBuildingLife.Domain.Commons;

public  class Auditable
{
    public long Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreateAtt { get; set; }
    public DateTime UpdateAtt { get; set; }
}
