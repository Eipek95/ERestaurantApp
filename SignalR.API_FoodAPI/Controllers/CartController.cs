using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public CartController(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetBasketDetail(string userId)
        {
            var values = await _cartService.BGetBasket(userId);
            return Ok(values);
        }

        [HttpGet("InitializeCart")]
        public async Task<IActionResult> InitializeCart(string userId)
        {
            await _cartService.BInitializeCart(userId);
            return Ok("Başarıyla Oluşturuldu");
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(Cart request)
        {
            await _cartService.BSaveBasket(request);
            return Ok("Başarıyla Kaydedildi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(int cartId, int productId)
        {
            await _cartService.BDeleteBasket(cartId, productId);
            return Ok("Başarıyla Silindi");
        }
        [HttpDelete("DeleteBasketByCartId")]
        public async Task<IActionResult> DeleteBasketByCartId(int cartId)
        {
            await _cartService.BDeleteBasket(cartId);
            return Ok("Başarıyla Silindi");
        }
    }
}
