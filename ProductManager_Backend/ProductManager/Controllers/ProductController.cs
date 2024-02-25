using Microsoft.AspNetCore.Mvc;
using ProductManager.Requests;
using ProductManager.Responses;
using ProductManager.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IProduct _productServices;

        public ProductController(IProduct product)
        {
            _productServices = product;
        }

        // GET: api/<ProductController>
        [HttpGet("GetAllProducts")]
        public async Task<List<ProductRes>> GetAll()
        {
            return await _productServices.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("GetAllByName/{Name}")]
        public async Task<List<ProductRes>>  GetAllByName(string Name)
        {
            return await _productServices.GetAllProductByName(Name);
        }

        // POST api/<ProductController>
        [HttpPost("AddProduct")]
        public async Task<ProductRes> AddProduct([FromBody] ProductReq productReq)
        {
            return await _productServices.AddProduct(productReq);
           
        }

        // PUT api/<ProductController>/5
        [HttpPut("updateProduct/{id}")]
        public async Task<ProductRes> updateProduct(int id, [FromBody] ProductReq productReq)
        {
            return await _productServices.updateProduct(productReq, id);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<int> Delete(int id)
        {
            return await _productServices.DeleteProduct(id);
        }
    }
}
