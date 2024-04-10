using Microsoft.AspNetCore.Mvc;
using RestWebApi.Contracts;
using RestWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    // GET: api/<ProductsController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Get()
    {
        if(!Autenticate())
        {
            return Unauthorized();
        }
        var products = await _productRepository.GetAllProducts();
        return Ok(products);
    }

    // GET api/<ProductsController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var product = await _productRepository.GetProductById(id);
        if(product == null)
        {
            return NotFound();
        }

        return Ok(product);

    }

    // POST api/<ProductsController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    public async Task<IActionResult> Post([FromBody] Product p)
    {
        Product newProduct = await _productRepository.AddNewProduct(p);
        return Ok(newProduct);  
    }

    //// PUT api/<ProductsController>/5
    [HttpPut()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put([FromBody] Product p)
    {
        bool updated = await _productRepository.Update(p);
        if(updated)
        {
            return Ok();
        }

        else
        {
            return NotFound();
        }
        
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool deleted = await _productRepository.Delete(id);

        if(deleted)
        {
            return Ok();
        }

        else
        {
            return NotFound(); ;
        }

    }

    private bool Autenticate()
    {
        bool isUserName =HttpContext.Request.Headers.TryGetValue("UserName",out  var value);
        bool isPassword = HttpContext.Request.Headers.TryGetValue("Password", out var pvalue);

        return isUserName && isPassword;

    }


}
