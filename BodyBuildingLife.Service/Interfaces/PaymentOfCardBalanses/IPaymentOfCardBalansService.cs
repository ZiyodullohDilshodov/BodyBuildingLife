using BodyBuildingLife.Service.DTOs.Card;
using BodyBuildingLife.Service.DTOs.CardDTOs;

namespace BodyBuildingLife.Service.Interfaces.PaymentOfCardBalanses;

public  interface IPaymentOfCardBalansService
{
    public Task<CardForResultDto> FillTheCard(PaymentOfCardBalansCreationDto paymentOfCardBalanceForCreationDto);
}
