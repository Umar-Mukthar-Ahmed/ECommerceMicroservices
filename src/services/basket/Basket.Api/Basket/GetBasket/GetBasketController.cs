
namespace Basket.Api.Basket.GetBasket
{
    //public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;

    public record GetbasketResponse(ShoppingCart cart);
    public class GetBasketController(ISender sender) : Controller
    {
        [HttpGet("basket/{userName}")]
        public async Task<ActionResult<GetbasketResponse>> GetBasket(string userName)
        {
            var result = await sender.Send(new GetBasketQuery(userName));

            var response = new GetbasketResponse(result.cart);

            return Ok(response);
        }
    }
}
