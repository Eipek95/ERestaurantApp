using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DtoLayer.BasketDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public BasketController(IBasketService basketService, IMapper mapper, IProductService productService)
        {
            _basketService = basketService;
            _mapper = mapper;
            _productService = productService;
        }



        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            var product = _productService.BGetById(createBasketDto.ProductID);
            Basket basket = new Basket();
            basket.ProductID = createBasketDto.ProductID;
            basket.UserID = createBasketDto.UserID;
            basket.Price = product.Price;
            basket.Count = 1;
            basket.TotalPrice = 0;
            _basketService.BAdd(basket);
            return Ok("Başarıyla Kaydedildi");
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.BGetById(id);
            _basketService.BDelete(value);
            return Ok("Başarıyla Silindi");
        }
    }
}
