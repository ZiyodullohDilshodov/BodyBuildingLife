using BodyBuildingLife.Service.DTOs.CardDTOs;
using BodyBuildingLife.Service.DTOs.Standards;
using BodyBuildingLife.Service.DTOs.PersonAsset;
using BodyBuildingLife.Service.DTOs.PersonProtainDTOs;
using BodyBuildingLife.Domain.Entities.PersonTreainers;
using BodyBuildingLife.Service.DTOs.PersonTrainerDTOs;

namespace BodyBuildingLife.Service.DTOs.Person;
public  class PersonForResultDto
{
    public long Id { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public long SportsCardId { get; set; }
    public long ProteinId { get; set; }
    public DateTime CreateAtt { get; set; }
    public DateTime UpdateAtt { get; set; }

    public ICollection<PersonProteinForResultDto> PersonProteins { get; set; }
    public ICollection<PersonAssetForResultDto> PersonAssets { get; set; }
    public ICollection<PersonStandardForResultDto> PersonStandards { get; set; }
    public ICollection<PersonTrainerForResultDto> PersonTrainers { get; set; }
}
