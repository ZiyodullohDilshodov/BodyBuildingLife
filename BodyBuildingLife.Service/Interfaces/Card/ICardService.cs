using BodyBuildingLife.Service.DTOs.Card;
using BodyBuildingLife.Service.DTOs.CardDTOs;

namespace BodyBuildingLife.Service.Interfaces.Card;

public  interface ICardService
{
    public Task<bool> DeleteAsync(long cardId);
    public  string Generate16DigitCardNumber();
    public string Generate4NumberValidityPeriod();
    public Task<CardForResultDto> RetruveByIdAsync(long id);
    public Task<IEnumerable<CardForResultDto>> RetrieveAllAsync();
    public Task<CardForResultDto> CardBlockUpdateAsync(CardForUpdateDto forUpdateDto);
    public Task<CardForResultDto> CreateAsync(CardForCreationDto forCreationDto);
    public Task<bool>CardBlocSolving(PaymentOfCardBalansCreationDto cardBlocSolvingDto);
    public Task<bool> CardBlocking(PaymentOfCardBalansCreationDto cardBlockingDto);

}
