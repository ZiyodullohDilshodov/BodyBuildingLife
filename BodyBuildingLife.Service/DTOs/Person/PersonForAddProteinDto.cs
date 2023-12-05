using BodyBuildingLife.Service.DTOs.ProtainDTOs;

namespace BodyBuildingLife.Service.DTOs.Person;

public  class PersonForAddProteinDto
{
    public ICollection<ProteinForCreationDto> Proteins { get; set; }
}
