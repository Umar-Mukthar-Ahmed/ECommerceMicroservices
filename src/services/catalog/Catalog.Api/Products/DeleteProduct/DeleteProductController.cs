using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Products.DeleteProduct
{
    public record DeleteProductResponse(bool IsSuccess);
    public class DeleteProductController(ISender sender) : Controller
    {
        [HttpDelete]
        [Route("api/products/delete/{id:guid}")]
        public async Task<ActionResult<DeleteProductResponse>> DeleteProduct(Guid id)
        {
            var command = new DeleteProductCommand(id);
            var result = await sender.Send(command);
            var response = new DeleteProductResponse(result.IsSuccess);
            return Ok(response);
        }
    }
}
