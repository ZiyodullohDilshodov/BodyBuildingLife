using BodyBuildingLife.Domain.Commons;

namespace BodyBuildingLife.Domain.Entities.Cards;

public  class Card : Auditable
{
    public string Phone {  get; set; }
    public long Money { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string CardNumber { get; set; }
    public string ValidityPeriod { get; set; }
    public bool CardIsBloced { get; set; }
   
}
