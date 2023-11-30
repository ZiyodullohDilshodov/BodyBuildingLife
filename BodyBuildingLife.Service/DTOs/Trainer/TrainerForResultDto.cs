using BodyBuildingLife.Service.DTOs.Person;
using BodyBuildingLife.Service.DTOs.TrainerAsset;

namespace BodyBuildingLife.Service.DTOs.TrainerDTOs;

public  class TrainerForResultDto
{
    public long Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime CreateAtt { get; set; }
    public DateTime UpdateAtt { get; set; }
    public string SportsSpecialist { get; set; }

    public ICollection<PersonForResultDto> Persons { get; set; }
    public ICollection<TrainerAssetForResultDto> TrainerAssets { get; set; }
}
