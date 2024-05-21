using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using asp.net_web_api.Models;

namespace asp.net_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<product> products = new List<product>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var product = products.SingleOrDefault(hh => hh.Id == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch 
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(productVM productVM) 
        {
            var product = new product
            {
                Id = Guid.NewGuid(),
                Name = productVM.Name,
                Description = productVM.Description,
                Price = productVM.Price
            };
            products.Add(product);
            return Ok(new
            {
                Success = true,
                Data = product
            });
        }
        [HttpPut("{id}")]
        public IActionResult Edit(string id, product productedit) 
        {
            try
            {
                var product = products.SingleOrDefault(hh => hh.Id == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                if ( id != product.Id.ToString())
                {
                    return BadRequest();
                }
                product.Name = productedit.Name;
                product.Description = productedit.Description;
                product.Price = productedit.Price;
                return  Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(string id) {
            try
            {
                var product = products.SingleOrDefault(hh => hh.Id == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                if (id != product.Id.ToString())
                {
                    return BadRequest();
                }
                products.Remove(product);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
