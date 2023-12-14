using BodyBuildingLife.Domain.Commons;
using BodyBuildingLife.Domain.Entities.Assets;
using BodyBuildingLife.Domain.Entities.PersonTreainers;

namespace BodyBuildingLife.Domain.Entities.Trainers;

public class Trainer : Auditable
{
    public string  FirstName { get; set; }
    public string  LastName { get ; set; }
    public  string  SportsSpecialist { get; set; }

    public string PasportSerialNumber { get; set; }
    public ICollection<PersonTrainer>Persons { get; set; }
    public ICollection<TrainerAsset> TrainerAssets { get; set; }

   
}
