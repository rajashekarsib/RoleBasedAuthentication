using Microsoft.AspNetCore.Mvc;
using ProductAPIVS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProductAPIVS.Container;
using ProductAPIVS.Entity;

namespace ProductAPIVS.Controllers
{

    [Authorize(Roles ="admin,user")]
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductContainer _DBContext;


        public ProductController(IProductContainer dBContext)
        {
            this._DBContext = dBContext;
        }

        //[HttpGet("GetAll")]
        //public async Task<IActionResult> GetAll()
        //{
        //    var product = await this._DBContext.GetAll();
        //    return Ok(product);
        //}
        //[HttpGet("GetbyCode/{code}")]
        //public async Task<IActionResult> GetbyCode(int code)
        //{
        //    var product = await this._DBContext.GetbyCode(code);
        //    return Ok(product);
        //}

        //[Authorize(Roles = "admin")]
        //[HttpDelete("Remove/{code}")]
        //public async Task<IActionResult> Remove(int code)
        //{
        //    var product = await this._DBContext.Remove(code);
        //    return Ok(false);
        //}

        ////[Authorize(Roles ="admin")]
        //[HttpPost("Create")]
        //public async Task<IActionResult> Create([FromBody] ProductEntity _product)
        //{
        //    var product = await this._DBContext.Save(_product);
        //    return Ok(true);
        //}

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var product = await this._DBContext.GetProducts();
            return Ok(product);

        }
        [HttpGet("GetProductbyCode")]
        public async Task<IActionResult> GetProductbyCode(int code)
        {
            var product = await this._DBContext.GetProductbyCode(code);
            return Ok(product);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("RemoveProduct/{code}")]
        public async Task<IActionResult> RemoveProduct(int code)
        {
            var product = await this._DBContext.RemoveProduct(code);
            return Ok(false);
        }

        [Authorize(Roles ="admin")]
        [HttpPost("SaveProduct")]
        public async Task<IActionResult> SaveProduct([FromBody] TblProduct _product)
        {
            var product = await this._DBContext.SaveProduct(_product);
            return Ok(true);
        }
    }
}