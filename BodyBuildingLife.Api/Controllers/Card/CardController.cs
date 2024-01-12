using Microsoft.AspNetCore.Mvc;
using BodyBuildingLife.Service.DTOs.CardDTOs;
using BodyBuildingLife.Service.Interfaces.Card;
using BodyBuildingLife.Service.DTOs.Card;
using BodyBuildingLife.Service.Interfaces.PaymentOfCardBalanses;
namespace BodyBuildingLife.Api.Controllers.Card;


public class CardController : BaseController
{
    
    private readonly ICardService _cardService;
    private readonly IPaymentOfCardBalansService _paymentOfCardBalansService;

    public CardController(ICardService cardService, IPaymentOfCardBalansService paymentOfCardBalansService)
    {
        _cardService = cardService;
        _paymentOfCardBalansService = paymentOfCardBalansService;
    }

    [HttpGet("{card-id}")]
    public async Task<IActionResult> GetAllAsync([FromRoute(Name = "card-id")] long  id)
    {
        var card = await _cardService.RetruveByIdAsync(id);
        return Ok(card);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
       var cards = await  _cardService.RetrieveAllAsync();
       return Ok(cards);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody]CardForCreationDto cardForCreationDto)
    {
        var card = await _cardService.CreateAsync(cardForCreationDto);
        return Ok(card);
    }

    [HttpDelete("{card-id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "card-id")] long id)
    {
        var card = await _cardService.DeleteAsync(id);
        return Ok(card);
    }

    [HttpPatch("fill")]
    public async Task<IActionResult> FillTheCardAsync([FromBody] PaymentOfCardBalansCreationDto paymentOfCardBalansCreationDto)
        => Ok(await _paymentOfCardBalansService.FillTheMoneyFromCard(paymentOfCardBalansCreationDto));

    [HttpPatch("Solve")]
    public async Task<IActionResult> SolvetheMoneyAsync([FromBody] PaymentOfCardBalansCreationDto paymentOfCardBalansCreationDto)
        => Ok(await _paymentOfCardBalansService.SolveTheMoneyFromCard(paymentOfCardBalansCreationDto));

    [HttpPatch("Block")]
    public async Task<IActionResult> CardBlockAsync([FromBody]CardBlockForCreationDto cardBlockForCreationDto)
        =>Ok(await _cardService.CardBlocking(cardBlockForCreationDto));

    [HttpPatch("UnBlock")]
    public async Task<IActionResult> SolveCardBlockAsync([FromBody]CardBlockForCreationDto solveCardBlocking)
        =>Ok(await _cardService.CardBlockSolving(solveCardBlocking));

}
