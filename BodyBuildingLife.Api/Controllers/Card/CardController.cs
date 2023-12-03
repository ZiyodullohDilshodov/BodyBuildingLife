using Microsoft.AspNetCore.Mvc;
using BodyBuildingLife.Service.DTOs.CardDTOs;
using BodyBuildingLife.Service.Interfaces.Card;
namespace BodyBuildingLife.Api.Controllers.Card;


public class CardController : BaseController
{
    
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
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

}
