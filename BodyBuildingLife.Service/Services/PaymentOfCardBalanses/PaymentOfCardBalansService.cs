using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Service.DTOs.Card;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Service.Exceptions;
using BodyBuildingLife.Service.DTOs.CardDTOs;
using BodyBuildingLife.Domain.Entities.Cards;
using BodyBuildingLife.Service.Interfaces.PaymentOfCardBalanses;

namespace BodyBuildingLife.Service.Services.PaymentOfCardBalanses;

public class PaymentOfCardBalansService : IPaymentOfCardBalansService
{
    private readonly IMapper _mapper;
    private readonly ICardRepository _cardRepositor;

    public PaymentOfCardBalansService(IMapper mapper, ICardRepository cardRepository)
    {
        _mapper = mapper;
        _cardRepositor = cardRepository;
    }

    public async Task<CardForResultDto> FillTheMoneyFromCard(PaymentOfCardBalansCreationDto paymentOfCardBalanceForCreationDto)
    {
        var card = await _cardRepositor.RetriveAllAsync()
            .Where(c=>c.ValidityPeriod == paymentOfCardBalanceForCreationDto.ValidityPeriod && c.CardNumber == paymentOfCardBalanceForCreationDto.CardNumber)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (card is null || card.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Card is not found");

        if (card.CardIsBloced == true)
            throw new BodyBuildingLifeException(401, "Card is blocked");
            
        var mappedCard = _mapper.Map<Card>(card);
        mappedCard.Money = card.Money + paymentOfCardBalanceForCreationDto.Money;

        return _mapper.Map<CardForResultDto>(await _cardRepositor.UpdateAsync(mappedCard));
    }

    public async Task<CardForResultDto> SolveTheMoneyFromCard(PaymentOfCardBalansCreationDto paymentOfCardBalanceForCreationDto)
    {
        var card = await _cardRepositor.RetriveAllAsync()
           .Where(c => c.ValidityPeriod == paymentOfCardBalanceForCreationDto.ValidityPeriod && c.CardNumber == paymentOfCardBalanceForCreationDto.CardNumber)
           .AsNoTracking()
           .FirstOrDefaultAsync();

        if (card is null || card.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Card is not found");

        if (card.CardIsBloced == true)
            throw new BodyBuildingLifeException(401, "Card is blocked");

        var mappedCard = _mapper.Map<Card>(card);
        mappedCard.Money = card.Money - paymentOfCardBalanceForCreationDto.Money;

        return _mapper.Map<CardForResultDto>(await _cardRepositor.UpdateAsync(mappedCard));
    }
}
