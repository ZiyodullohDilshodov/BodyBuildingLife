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
    public Task<CardForResultDto> CreateAsync(CardForCreationDto forCreationDto);
    public Task<bool> CardBlocking(CardBlockForCreationDto cardBlockingDto);
    public Task<CardForResultDto> CardIsBlockingAsync(CardForUpdateDto forUpdateDto);
    public Task<bool>CardBlockSolving(CardBlockForCreationDto cardBlocSolvingDto);
    public  Task<CardForResultDto> CardIsUnBlockAsync(CardForUpdateDto forUpdateDto);

}
