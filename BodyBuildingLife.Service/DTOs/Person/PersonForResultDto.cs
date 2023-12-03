using BodyBuildingLife.Service.DTOs.CardDTOs;
using BodyBuildingLife.Service.DTOs.PersonAsset;
using BodyBuildingLife.Service.DTOs.ProtainDTOs;
using BodyBuildingLife.Service.DTOs.Standards;

namespace BodyBuildingLife.Service.DTOs.Person;
public  class PersonForResultDto
{
    public long Id { get; set; }
    public string Phone { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public long SportsCardId { get; set; }
    public DateTime CreateAtt { get; set; }
    public DateTime UpdateAtt { get; set; }

    public ICollection<CardForResultDto> Cards { get; set; }
    public ICollection<ProteinForResultDto> Proteins { get; set; }
    public ICollection<PersonAssetForResultDto> PersonAssets { get; set; }
    public ICollection<ProteinStandardsForResultDto> ProteinStandards { get; set; }
}
