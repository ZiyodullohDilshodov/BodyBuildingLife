using AutoMapper;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Domain.Entities.Cards;
using BodyBuildingLife.Service.DTOs.CardDTOs;
using BodyBuildingLife.Service.Exceptions;
using BodyBuildingLife.Service.Interfaces.Card;
using Microsoft.EntityFrameworkCore;

namespace BodyBuildingLife.Service.Services;

public class CardService : ICardService
{
    private readonly IMapper _mapper;
    private readonly ICardRepository _cardRepository;
    private readonly IPersonRepository _personRepository;


    public CardService(IMapper mapper, ICardRepository cardRepository , IPersonRepository personRepository)
    {
        this._mapper = mapper;
        this._cardRepository = cardRepository;
        this._personRepository = personRepository;

    }

    public async Task<CardForResultDto> CreateAsync(CardForCreationDto forCreationDto)
    {
       var checkPerson = await _personRepository.RetriveAllAsync()
            .Where(p=>p.PasportSeriaNumber == forCreationDto.PasportSeriaNumber)
            .FirstOrDefaultAsync();

        if (checkPerson is null)
            new BodyBuildingLifeException(404, "Person is not found.");

        if (checkPerson.SportsCardId != 0)
            new BodyBuildingLifeException(409, "The person has a card");

       

        var mappedCard = _mapper.Map<Card>(forCreationDto);
        mappedCard.CardNumber = Generate16DigitCardNumber();
        mappedCard.ValidityPeriod = Generate4NumberValidityPeriod();
        mappedCard.Phone = checkPerson.Phone;
        mappedCard.CreateAtt = DateTime.UtcNow;
   
        var requestCardData = await _cardRepository.CreateAsync(mappedCard);

        var resultMappedCardData = _mapper.Map<CardForResultDto>(requestCardData);
        checkPerson.SportsCardId = resultMappedCardData.Id;

        

        string Generate4NumberValidityPeriod()
        {
            Random random = new Random();

            int[] number_1 = new int[2];
            for(int i = 1;i<2;i++)
            {
                int digit = random.Next(10);
                number_1[i] = digit;
            }

            int[] number_2 = new int[2];
            for (int i = 1; i < 2; i++)
            {
                int digit = random.Next(10);
                number_2[i] = digit;
            }

            string validityPeriodNumber = number_1.ToString() + "/" + number_2.ToString();

            return validityPeriodNumber;
        }


        string  Generate16DigitCardNumber()
        {
            Random random = new Random();

            int[] number = new int[16];

            for (int i = 0; i < 16; i++)
            {
                int digit = random.Next(10);

                number[i] = digit;
            }
            return number.ToString();
        }

        return resultMappedCardData;

    }

    public async Task<bool> DeleteAsync(long cardId)
    {
        var checkCard = await _cardRepository.RetriveAllAsync()
            .Where(c => c.Id == cardId)
            .FirstOrDefaultAsync();
        if (checkCard == null)
            new BodyBuildingLifeException(404, "Card is not found");

        bool deleted = checkCard.IsDeleted = true;
        checkCard.CardIsBloced = true;

        return deleted;
    }

    public async Task<IEnumerable<CardForResultDto>> RetrieveAllAsync()
    {
        var cardData = _cardRepository.RetriveAllAsync();

        var resultMappedCardData = _mapper.Map<IEnumerable<CardForResultDto>>(cardData);

        return resultMappedCardData;
    }

    public async Task<CardForResultDto> RetruveByIdAsync(long id)
    {
        var searchCard = await _cardRepository.GetByIdAsync(id);
        if (searchCard == null)
            new BodyBuildingLifeException(404, "Card is not found");

        return _mapper.Map<CardForResultDto>(searchCard);
    }

    public Task<CardForResultDto> UpdateAsync(CardForUpdateDto forUpdateDto)
    {
        //To Do LOGIC
        throw new NotImplementedException();
    }
}
