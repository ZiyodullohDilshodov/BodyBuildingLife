using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Service.Exceptions;
using BodyBuildingLife.Domain.Entities.Cards;
using BodyBuildingLife.Service.DTOs.CardDTOs;
using BodyBuildingLife.Service.Interfaces.Card;
using BodyBuildingLife.Service.DTOs.Card;

namespace BodyBuildingLife.Service.Services;

public class CardService : ICardService
{
    private readonly IMapper _mapper;
    private readonly ICardRepository _cardRepository;
    private readonly IPersonRepository _personService;


    public CardService(IMapper mapper, ICardRepository cardRepository , IPersonRepository personService)
    {
        this._mapper = mapper;
        this._cardRepository = cardRepository;
        this._personService = personService;

    }

    public async Task<bool> CardBlocking(PaymentOfCardBalansCreationDto cardBlockingDto)
    {
        var mappedCard = _mapper.Map<CardForUpdateDto>(cardBlockingDto);
        mappedCard.CardIsBloced = true ;
        var result = await CardBlockUpdateAsync(mappedCard);

        if (result.CardIsBloced == true )
            return  true  ;
        return false  ;
    }

    public async Task<bool> CardBlocSolving(PaymentOfCardBalansCreationDto cardBlocSolvingDto)
    {
        var mappedCard = _mapper.Map<CardForUpdateDto>(cardBlocSolvingDto);
        mappedCard.CardIsBloced = false;
        var result = await CardBlockUpdateAsync(mappedCard);

        if (result.CardIsBloced == false)
            return true;
        return false;
    }

    public async Task<CardForResultDto> CreateAsync(CardForCreationDto forCreationDto)
    {
       var checkPerson = await _personService.RetriveAllAsync()
            .Where(p=>p.PasportSeriaNumber == forCreationDto.PasportSeriaNumber)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (checkPerson is null)
           throw  new BodyBuildingLifeException(404, "Person is not found.");

        if (checkPerson.SportsCardId != 0)
           throw new BodyBuildingLifeException(409, "The person has a card");

       

        var mappedCard = _mapper.Map<Card>(forCreationDto);
        mappedCard.CardNumber = Generate16DigitCardNumber();
        mappedCard.ValidityPeriod = Generate4NumberValidityPeriod();
        mappedCard.Phone = checkPerson.Phone;
        mappedCard.CreateAtt = DateTime.UtcNow;
   
        var requestCardData = await _cardRepository.CreateAsync(mappedCard);

        var resultMappedCardData = _mapper.Map<CardForResultDto>(requestCardData);
        checkPerson.SportsCardId = resultMappedCardData.Id;
       
        var updatePerson = await _personService.UpdateAsync(checkPerson);

        return resultMappedCardData;

    }

    public async Task<bool> DeleteAsync(long cardId)
    {
        var checkCard = await _cardRepository.RetriveAllAsync()
            .Where(c => c.Id == cardId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (checkCard == null || checkCard.IsDeleted==true)
           throw new BodyBuildingLifeException(404, "Card is not found");

        checkCard.CardIsBloced = true;
        checkCard.UpdateAtt = DateTime.UtcNow;
        bool deleted = checkCard.IsDeleted = true;

        var mappedCardData = _mapper.Map<Card>(checkCard);
        var result = await _cardRepository.UpdateAsync(mappedCardData);

        if(result.IsDeleted == false)
            return false;
        else
            return true;
        
    }

    public string Generate16DigitCardNumber()
    {
        Random random = new Random();

        int[] number = new int[16];

        for (int i = 0; i < 16; i++)
        {
            int digit = random.Next(10);

            number[i] = digit;
        }
        return string.Join("",number);
    }

    public string Generate4NumberValidityPeriod()
    {
        Random random = new Random();

        int[] number_1 = new int[2];
        for (int i = 0; i < 2; i++)
        {
            int digit = random.Next(10);
            number_1[i] = digit;
        }

        int[] number_2 = new int[2];
        for (int i = 0; i < 2; i++)
        {
            int digit = random.Next(10);
            number_2[i] = digit;
        }

        string validityPeriodNumber = string.Join("", number_1) + '/' + string.Join("", number_2);

        return validityPeriodNumber;
    }


    
    public async Task<IEnumerable<CardForResultDto>> RetrieveAllAsync()
    {
        var cardData =await _cardRepository.RetriveAllAsync()
            .Where(card=>card.IsDeleted == false)
            .AsNoTracking()
            .ToListAsync();

        var resultMappedCardData = _mapper.Map<IEnumerable<CardForResultDto>>(cardData);

        return resultMappedCardData;
    }

    public async Task<CardForResultDto> RetruveByIdAsync(long id)
    {
        var searchCard = await _cardRepository.RetriveAllAsync()
            .Where(card=>card.Id==id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (searchCard == null || searchCard.IsDeleted == true)
           throw  new BodyBuildingLifeException(404, "Card is not found");

        if (searchCard.CardIsBloced = true)
            throw new BodyBuildingLifeException(401, "Card is bLocked");

        return _mapper.Map<CardForResultDto>(searchCard);
    }

    public async Task<CardForResultDto> CardBlockUpdateAsync(CardForUpdateDto forUpdateDto)
    {
        var card = await _cardRepository.RetriveAllAsync()
            .Where(c => c.CardNumber == forUpdateDto.CardNumber && c.ValidityPeriod == forUpdateDto.ValidityPeriod)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (card is null || card.IsDeleted == true)
            throw new BodyBuildingLifeException(404, "Card is not found");

        if (card.CardIsBloced = true)
            throw new BodyBuildingLifeException(401, "Card is bLocked");

        var mappedCard =  _mapper.Map<Card>(forUpdateDto);
        mappedCard.Id = card.Id;
        mappedCard.UpdateAtt = DateTime.UtcNow;

        return _mapper.Map<CardForResultDto>(await _cardRepository.UpdateAsync(mappedCard));
    }
}
