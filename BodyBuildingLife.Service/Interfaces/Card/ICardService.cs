using BodyBuildingLife.Service.DTOs.CardDTOs;

namespace BodyBuildingLife.Service.Interfaces.Card;

public  interface ICardService
{
    public Task<bool> DeleteAsync(long cardId);
    public Task<CardForResultDto> RetruveByIdAsync(long id);
    public Task<IEnumerable<CardForResultDto>> RetrieveAllAsync();
    public Task<CardForResultDto> UpdateAsync(CardForUpdateDto forUpdateDto);
    public Task<CardForResultDto> CreateAsync(CardForCreationDto forCreationDto);

}
