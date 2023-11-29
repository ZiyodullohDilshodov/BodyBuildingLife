namespace BodyBuildingLife.Service.DTOs.TrainerDTOs;

public  class TrainerForCreationDto
{
    public long Id { get; set; }
    public bool IsDeleted { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime CreateAtt { get; set; }
    public DateTime UpdateAtt { get; set; }
    public string SportsSpecialist { get; set; }
}
