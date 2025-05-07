using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Products.GetProductsByCategory;
public record GetProductsByCategoryResponse(IEnumerable<Product> products);

    public class GetProductsByCategoryController(ISender sender) : Controller
    {
        [HttpGet("{category}")]
        public async Task<ActionResult<GetProductsByCategoryResponse>> Get(string category)
        {
            var result = await sender.Send(new GetProductsByCategoryQuery(category));
            var response = new GetProductsByCategoryResponse(result.Products);
            return Ok(response);
        }
    }

