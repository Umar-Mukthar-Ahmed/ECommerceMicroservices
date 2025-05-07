namespace Catalog.Api.Products.GetProducts
   
{
    public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);
    public record GetProductsResponse(IEnumerable<Product> Products);

    [ApiController]
    [Route("api/[controller]")]
    public class GetProductsController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<GetProductsResponse>> GetAll([FromQuery] GetProductsRequest request , CancellationToken cancellationToken)
        {
            var query = request.Adapt<GetProductsQuery>();

            var result = await sender.Send(query);

            var response = result.Adapt<GetProductsResponse>();

            return Ok(result);
        }
    }
}
