
using MediatR;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Products.CreateProduct;

[ApiController]
[Route("api/[controller]")]
public class CreateProductController : ControllerBase
{
    private readonly ISender _sender;

    public CreateProductController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult<CreateProductResult>> Create([FromBody] CreateProductCommand request)
    {
        var command = request.Adapt<CreateProductCommand>();
        var result = await _sender.Send(command);
        var response = result.Adapt<CreateProductResult>();

        return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
    }
}
