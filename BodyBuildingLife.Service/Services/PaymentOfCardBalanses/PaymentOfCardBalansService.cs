using BodyBuildingLife.Service.DTOs.Card;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Service.DTOs.CardDTOs;
using BodyBuildingLife.Service.Interfaces.PaymentOfCardBalanses;
using BodyBuildingLife.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BodyBuildingLife.Domain.Entities.Cards;
using BodyBuildingLife.Service.Interfaces.Card;

namespace BodyBuildingLife.Service.Services.PaymentOfCardBalanses;

public class PaymentOfCardBalansService //: IPaymentOfCardBalansService
{
    private readonly IMapper _mapper;
    private readonly ICardService _cardService;

    public PaymentOfCardBalansService(IMapper mapper, ICardService cardService)
    {
        _mapper = mapper;
        _cardService = cardService;
    }



    //public async Task<CardForResultDto> FillTheCard(MoneyAddenAndSubtractForCardDto paymentOfCardBalanceForCreationDto)
    //{
        

    //}

   
}
