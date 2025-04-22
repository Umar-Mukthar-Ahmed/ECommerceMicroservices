//using Catalog.Api.Models;
//using Catalog.Api.Products.CreateProduct;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Mapster;

//namespace Catalog.Api.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class ProductsController : ControllerBase
//    {
//        private readonly ISender _sender;

//        public ProductsController(ISender sender)
//        {
//            _sender = sender;
//        }

//        [HttpPost]
//        public async Task<ActionResult<CreateProductResponse>> CreateProduct([FromBody] CreateProductRequest request)
//        {
//            var command = request.Adapt<CreateProductCommand>();
//            var result = await _sender.Send(command);
//            var response = result.Adapt<CreateProductResponse>();

//            return CreatedAtAction(nameof(GetProductById), new { id = response.Id }, response);
//        }

//        [HttpGet("{id}")]
//        public IActionResult GetProductById(Guid id)
//        {
//            return Ok(); // placeholder
//        }
//    }

//    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
//    public record CreateProductResponse(Guid Id);
//}
