using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);

    public record UpdateProductResponse(bool IsSuccess);
    public class UpdateProductController(ISender sender)
        : Controller
    {
        [HttpPut]
        [Route("api/products/update")]
        public async Task<ActionResult<UpdateProductResponse>> UpdateProduct([FromBody] UpdateProductRequest request)
        { 
            var command = request.Adapt<UpdateProductCommand>();

            var result = await sender.Send(command);

        return Ok(result);
    }

    }
}
