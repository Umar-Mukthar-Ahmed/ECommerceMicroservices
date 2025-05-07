using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Products.CreateProduct;

public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
public record CreateProductResponse(Guid Id);

[ApiController]
[Route("api/[controller]")]
public class CreateProductController(ISender sender) : ControllerBase
{

    [HttpPost]
    public async Task<ActionResult<CreateProductResponse>> Create([FromBody] CreateProductRequest request)
    {
        var command = request.Adapt<CreateProductCommand>();
        var result = await sender.Send(command);
        var response = result.Adapt<CreateProductResponse>();

        return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
    }
}
