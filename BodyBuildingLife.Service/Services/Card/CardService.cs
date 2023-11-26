using AutoMapper;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Service.DTOs.CardDTOs;
using BodyBuildingLife.Service.Interfaces.Card;

namespace BodyBuildingLife.Service.Services.Card;

public class CardService : ICardService
{
    private readonly IMapper _mapper;

    private readonly ICardRepository _cardRepository;

    public CardService(IMapper mapper, ICardRepository cardRepository)
    {
        this._mapper = mapper;
        this._cardRepository = cardRepository;

    }

    public async Task<CardForResultDto> CreateAsync(CardForCreationDto forCreationDto)
    {
       // var card = await _cardRepository.RetriveAllAsync().Where()
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long cardId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CardForResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CardForResultDto> RetruveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<CardForResultDto> UpdateAsync(CardForUpdateDto forUpdateDto)
    {
        throw new NotImplementedException();
    }
}
