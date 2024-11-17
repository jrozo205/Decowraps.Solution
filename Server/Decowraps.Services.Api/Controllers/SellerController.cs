using Decowraps.Services.Application.DTOs;
using Decowraps.Services.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Decowraps.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerService;
        public SellerController(ISellerService sellerService) 
        {
            _sellerService = sellerService;
        }


        // GET: api/<SellerController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SellerDTO>>> Get()
        {
            try
            {
                var result = await _sellerService.GetAllSellers();
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // GET api/<SellerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SellerDTO>> Get(int id)
        {
            try
            {
                var result = await _sellerService.GetSellerById(id);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex);
            }
        }

        // POST api/<SellerController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SellerDTO seller)
        {
            try 
            {
                var result = await _sellerService.CreateSeller(seller);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // PUT api/<SellerController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] SellerDTO seller)
        {
            try
            {
                seller.SellerId = id;
                var result = _sellerService.UpdateSeller(seller);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // DELETE api/<SellerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _sellerService.DeleteSeller(id);
                return Ok();
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex);
            }
        }
    }
}
