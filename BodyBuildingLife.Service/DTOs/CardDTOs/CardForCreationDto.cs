namespace BodyBuildingLife.Service.DTOs.CardDTOs;

public  class CardForCreationDto
{
    public long Money { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime CreateAtt { get; set; }
    public DateTime UpdateAtt { get; set; }
    public string PasportSeriaNumber { get; set; }
}
