using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Models;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { id = 1, name = "Teclado", price = 150.00M },
            new Product { id = 2, name = "Mouse"  , price = 90.00M }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product product = _products.FirstOrDefault(p => p.id == id);
            if (product == null) 
                return NotFound("Não foi possível encontrar :(");
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {
            product.id = _products.Max(p => p.id) + 1;
            _products.Add(product);
            return CreatedAtAction(nameof(Get), new {id = product.id }, product);
        }
    }
}
