using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DtoLayer.OrderDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper, IProductService productService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount() => Ok(_orderService.BTotalOrderCount());
        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount() => Ok(_orderService.BActiveOrderCount());
        [HttpGet("PassiveOrderCount")]
        public IActionResult PassiveOrderCount() => Ok(_orderService.BPassiveOrderCount());
        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice() => Ok(_orderService.BLastOrderPrice());
        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice() => Ok(_orderService.BTodayTotalPrice());

        [HttpPost]
        public async Task<IActionResult> SaveOrder(CreateOrderDto orderDto)
        {
            orderDto.Date = DateTime.Now;
            var order = _mapper.Map<Order>(orderDto);
            await _orderService.BSaveOrder(order);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderByOrderStatus(string orderStatus)
        {
            var order = await _orderService.BGetOrderByOrderStatus(orderStatus);
            return Ok(order);
        }

        [HttpGet("GetOrderByUserId")]
        public async Task<IActionResult> GetOrderByUserId(string userId)
        {
            var order = await _orderService.BGetOrderByUserId(userId);
            var orderDto = _mapper.Map<List<ResultOrderDto>>(order);
            return Ok(orderDto);
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var order = _orderService.BGetAll();
            return Ok(order.OrderByDescending(x => x.Date));
        }
        [HttpGet("TopSellingProduct")]
        public IActionResult TopSellingProduct() => Ok(_orderService.BTopSellingProduct());
        [HttpGet("SellingProductCount")]
        public IActionResult SellingProductCount() => Ok(_orderService.BSellingProductCount());

        [HttpGet("SaveRandomOrder")]
        public async Task<IActionResult> SaveRandomOrder()
        {

            var userCart = new Dictionary<string, int>();
            userCart.Add("61974125-e923-4a95-876d-3d1c4375e4e8", 1003);
            userCart.Add("5a48a6c2-dbe5-4fca-8d0e-ffedfa7baa1a", 2005);

            var orders = new List<Order>();

            Random random = new Random();
            DateTime startDate = new DateTime(2024, 1, 1);
            DateTime endDate = new DateTime(2024, 9, 30);
            Array enumValues = Enum.GetValues(typeof(OrderEnum));


            var userIds = new List<string>(userCart.Keys);
            var products = _productService.BGetAll();
            var randomDate = GetRandomDate(startDate, endDate);

            //zamanı 10 kere değiştir
            for (int dateCount = 1; dateCount <= 10; dateCount++)
            {
                var randomUserId = userIds[random.Next(userIds.Count)];
                var randomCartId = userCart[randomUserId];
                var order = new Order();
                decimal top = 0;
                order.OrderDetails = new List<OrderDetail>();

                //değiştirdiğin zamana siparişleri ekle 100 tane
                for (int i = 1; i < 5; i++)
                {
                    var randomQuantity = random.Next(1, 10);
                    var selectedProduct = products[random.Next(1, 4)];
                    var isl = selectedProduct.Price * randomQuantity;
                    top += isl;
                    //var selectedProduct = products[random.Next(1, 9)];

                    order.CartId = randomCartId;
                    order.Price = top;
                    order.DiscountPrice = null;
                    order.DiscountAmount = null;
                    order.DiscountCode = "yok";
                    order.UserId = randomUserId;
                    order.OrderStatus = enumValues.GetValue(random.Next(0, enumValues.Length))!.ToString();
                    order.Date = randomDate;

                    if (order.OrderDetails.Count == 0)
                    {
                        order.OrderDetails.Add(new OrderDetail
                        {
                            OrderId = 0,
                            ProductID = selectedProduct.Id,
                            Quantity = randomQuantity,
                        });
                    }
                    else
                    {
                        if (!order.OrderDetails.Any(x => x.ProductID == selectedProduct.Id))
                        {
                            order.OrderDetails.Add(new OrderDetail
                            {
                                OrderId = 0,
                                ProductID = selectedProduct.Id,
                                Quantity = randomQuantity,
                            });
                        }
                        else
                        {
                            var existingItem = order.OrderDetails.First(x => x.ProductID == selectedProduct.Id);
                            existingItem.Quantity += randomQuantity;
                        }
                    }
                }
                await _orderService.BSaveOrder(order);
                randomDate = GetRandomDate(startDate, endDate);
            }


            return Ok();
        }

        private static DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {
            Random random = new Random();
            int range = (endDate - startDate).Days;
            return startDate.AddDays(random.Next(range));
        }
        public enum OrderEnum
        {
            Hazirlaniyor,
            Kuryede,
            TeslimEdildi,
            IptalEdildi_Restoran,
            IptalEdildi_Musteri
        }
    }

}
