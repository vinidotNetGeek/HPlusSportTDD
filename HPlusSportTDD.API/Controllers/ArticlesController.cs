using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HPlusSportTDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        // GET: api/<ArticlesController>
        //[HttpGet]
        public List<Article> _articles => new List<Article>()
        {
            new Article(){Id=1, Name="Red shirt"},
            new Article(){Id=2, Name="Blue Shirt"}
        };


        [HttpGet]
        public IEnumerable<Article> GetAll()
        {
            return _articles;
        }

        // GET api/<ArticlesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var article = _articles.Find(a => a.Id == id);
            if(article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }
    }
}
