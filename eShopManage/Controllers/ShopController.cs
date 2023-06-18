using eShopManage.Dtos.Common;
using eShopManage.Dtos.ShopDtos;
using eShopManage.Services.ShopServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShopManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }
        [HttpGet("get-provider-with-point")]
        public IActionResult GetProvider(int id)
        {
            var result = _shopService.getWithPoint(id);
            return Ok(result);
        }
        [HttpGet("get-all")]
        public IActionResult GetAll([FromQuery] FilterDto input)
        {
            var result = _shopService.getWithPaging(input);
            return Ok(result);
        }
        [HttpPost("Create")]
        public IActionResult Create(CreateShopDto input)
        {
            try
            {
                _shopService.CreateShop(input);
                return Ok("Thêm thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-by-id")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _shopService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-shop")]
        public IActionResult Update(UpdateShopDto input)
        {
            try
            {
                _shopService.UpdateShop(input);
                return Ok("cập nhật thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-by-id")]
        public IActionResult Delete(int id)
        {
            try
            {
                _shopService.DeleteShop(id);
                return Ok("Xóa thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
