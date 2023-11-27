using BodyBuildingLife.Domain.Commons;

namespace BodyBuildingLife.Domain.Entities.Cards;

public  class Card : Auditable
{
    public long  Money { get; set; }
    public string Phone { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string  Password { get; set; } 
    public string CardNumber { get; set; }
    public string  ValidityPeriod { get ; set; } 
    public string PasportSeriaNumber { get; set; }
    public bool CardIsBloced { get; set; }


}
