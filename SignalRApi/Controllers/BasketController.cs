using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BasketDto;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTableID(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }

        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id).Select(x => new ResultBasketListWithProductsDto
            {
                BasketID = x.BasketID,
                Count = x.Count,
                MenuTableID = x.MenuTableID,
                Price = x.Price,
                ProductID = x.ProductID,
                ProductName = x.Product.ProductName,
                TotalPrice = x.TotalPrice
            }).ToList();

            return Ok(values);
        }
    }
}
