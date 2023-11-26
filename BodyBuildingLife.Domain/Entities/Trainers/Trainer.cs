using BodyBuildingLife.Domain.Commons;
using BodyBuildingLife.Domain.Enums;

namespace BodyBuildingLife.Domain.Entities.Trainers;

public class Trainer : Auditable
{
   public string  FirstName { get; set; }
   public string  LastName { get ; set; }
   public  string  SportsSpecialist { get; set; }

}
