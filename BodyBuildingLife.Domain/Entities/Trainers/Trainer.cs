using BodyBuildingLife.Domain.Commons;
using BodyBuildingLife.Domain.Entities.Assets;
using BodyBuildingLife.Domain.Entities.Persons;

namespace BodyBuildingLife.Domain.Entities.Trainers;

public class Trainer : Auditable
{
    public string  FirstName { get; set; }
    public string  LastName { get ; set; }
    public  string  SportsSpecialist { get; set; }

    public string PasportSerialNumber { get; set; }
    public ICollection<Person>Persons { get; set; }
    public ICollection<TrainerAsset> TrainerAssets { get; set; }

   
}
