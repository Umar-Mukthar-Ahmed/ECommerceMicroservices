using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Products.GetProductById
{
    public record GetProductByIdResponse(Product product);

    [ApiController]
    [Route("api/[controller]")]
    public class GetProductByIdController(ISender sender) : Controller
    {

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetProductByIdResponse>> Get(Guid id)
        {
            var result = await sender.Send(new GetProductByIdQuery(id));
            var response = new GetProductByIdResponse(result.product);

            return Ok(response);
        }


    }
}
