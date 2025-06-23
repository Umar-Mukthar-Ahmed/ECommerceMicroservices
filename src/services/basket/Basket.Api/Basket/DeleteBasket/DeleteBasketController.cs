using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Basket.DeleteBasket
{
    //public record DeleteBasketRequest(string UserName);

    public record DeleteBasketResponse(bool IsSuccess);
    public class DeleteBasketController(ISender sender) : Controller
    {
        [HttpDelete("/basket/{userName}")]

        public async Task<ActionResult<DeleteBasketResponse>> DeleteBasket(string userName)
        {
            var result =await sender.Send(new DeleteBasketCommand(userName));

            var response = result.Adapt<DeleteBasketResponse>();

            return Ok(result);
        }
    }
}
