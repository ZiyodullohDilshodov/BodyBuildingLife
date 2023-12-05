using BodyBuildingLife.Service.DTOs.ProtainDTOs;

namespace BodyBuildingLife.Service.DTOs.PersonDTOs;

public  class PersonForUpdateDto
{
    public long Id { get; set; }
    public string Phone { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string PasportSeriaNumber { get; set; }

    public ICollection<ProteinForResultDto> Proteins { get; set; }
}
