using BodyBuildingLife.Service.DTOs.CardDTOs;
using BodyBuildingLife.Service.DTOs.PersonAsset;
using BodyBuildingLife.Service.DTOs.ProtainDTOs;

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
    public ICollection<ProtainForResultDto> Protains { get; set; }
    public ICollection<PersonAssetForResultDto> PersonAssets { get; set; }
}
