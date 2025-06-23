
namespace Basket.Api.Basket.StoreBasket
{
    public record StoreBasketRequest(ShoppingCart cart);

    public record StoreBasketResponse (string UserName);
    public class StoreBasketController(ISender sender) : Controller
    {
        [HttpPost("/basket")]
        public async Task<ActionResult<StoreBasketResponse>> StoreBasket([FromBody] StoreBasketRequest request)
        {
            var command = new StoreBasketCommand(request.cart);
            var result = await sender.Send(command);
            var response = result.Adapt<StoreBasketResponse>();
            return Ok(response);
        }
    }
}
