namespace BodyBuildingLife.Service.DTOs.CardDTOs;

public  class CardForUpdateDto
{
    public long Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string CardNumber { get; set; }
    public string ValidityPeriod { get; set; }
    public bool CardIsBloced { get; set; }

}
