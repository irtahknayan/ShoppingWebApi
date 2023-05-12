using Microsoft.AspNetCore.Mvc;
using ShoppingWebApi.EfCore;
using ShoppingWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingWebApi.Controllers
{
    
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly DbHelper _dbHelper;

        public ShoppingController(DataContext dataContext)
        {
            _dbHelper= new DbHelper(dataContext);
        }
        // GET: api/<ShoppingApiController>
        [HttpGet]
        [Route("api/[controller]/GetProducts")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try 
            {
                IEnumerable<ProductModel> data = _dbHelper.GetProducts();
                
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));

            }
            catch(Exception ex) 
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }  
        }

        // GET api/<ShoppingApiController>/5
        [HttpGet]
        [Route("api/[controller]/GetProductById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                ProductModel data = _dbHelper.GetProductById(id);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<ShoppingApiController>
        [HttpPost]
        [Route("api/[controller]/SaveOrder")]
        public IActionResult Post([FromBody] OrderModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _dbHelper.SaveOrder(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<ShoppingApiController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateOrder")]
        public IActionResult Put(int id, [FromBody] OrderModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _dbHelper.SaveOrder(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<ShoppingApiController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteOrder/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _dbHelper.DeleteOrder(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Deleted Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
