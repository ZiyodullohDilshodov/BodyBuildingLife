namespace BodyBuildingLife.Service.DTOs.PersonDTOs;

public  class PersonForResultDto
{
    public long Id { get; set; }
    public string Phone { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public long SportsCardId { get; set; }
    public DateTime CreateAtt { get; set; }
    public DateTime UpdateAtt { get; set; }
}
