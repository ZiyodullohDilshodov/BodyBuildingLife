using BodyBuildingLife.Domain.Commons;
using BodyBuildingLife.Domain.Entities.Assets;

namespace BodyBuildingLife.Domain.Entities.Trainers;

public class Trainer : Auditable
{
    public string  FirstName { get; set; }
    public string  LastName { get ; set; }
    public  string  SportsSpecialist { get; set; }

    public ICollection<TrainerAsset> TrainerAssets { get; set; }

   
}
