namespace BodyBuildingLife.Service.DTOs.CardDTOs;

public  class CardForResultDto
{
    public long Id { get; set; }
    public long Money { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string CardNumber { get; set; }
    public string ValidityPeriod { get; set; }
    public DateTime CreateAtt { get; set; }
    public DateTime UpdateAtt { get; set; }
    
}
