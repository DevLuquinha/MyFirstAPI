using Microsoft.AspNetCore.Mvc;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello, World! Luquinha is going well :)");
        }

        [HttpGet("nome/{nome}")]
        public IActionResult GetComNome(string nome)
        {
            return Ok($"Hello, {nome}! How's going? ");
        }
    }
}
