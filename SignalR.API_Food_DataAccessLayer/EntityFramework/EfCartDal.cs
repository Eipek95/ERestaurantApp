using Microsoft.EntityFrameworkCore;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Concrete;
using SignalR.API_Food_DataAccessLayer.Repositories;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.EntityFramework
{
    public class EfCartDal : GenericRepository<Cart>, ICartDal
    {
        public EfCartDal(SignalRContext context) : base(context)
        {
        }

        public async Task DeleteBasket(int cartId, int productId)
        {
            using var context = new SignalRContext();
            var basket = await context.CartItem.ToListAsync();
            var selectedItem = basket.Where(x => x.CartId == cartId & x.ProductId == productId).FirstOrDefault();
            context.CartItem.Remove(selectedItem);
            await context.SaveChangesAsync();

        }

        public async Task DeleteBasket(int cartId)
        {
            using var context = new SignalRContext();
            var basket = context.Carts.Where(x => x.Id == cartId).Include(x => x.CartItems).FirstOrDefault();
            basket.DiscountCode = "yok";
            basket.DiscountRate = 0;
            context.Carts.Update(basket);
            foreach (var item in basket.CartItems)
            {
                context.CartItem.Remove(item);
            }
            await context.SaveChangesAsync();
        }

        public async Task<Cart> GetBasket(string userId)
        {
            using var context = new SignalRContext();
            var basket = await context.Carts.Include(c => c.CartItems).ThenInclude(p => p.Product).FirstOrDefaultAsync(x => x.UserId == userId);
            return basket;
        }

        public async Task InitializeCart(string userId)
        {
            var newBasket = new Cart
            {
                UserId = userId,
                DiscountCode = "yok",
                DiscountRate = 0,
                CartItems = new List<CartItem>(),
            };

            using var context = new SignalRContext();
            await context.Carts.AddAsync(newBasket);
            await context.SaveChangesAsync();
        }

        public async Task SaveBasket(Cart basketTotalDto)
        {
            using var context = new SignalRContext();
            var basketItem = await GetBasket(basketTotalDto.UserId);
            var updatedBasketItem = basketTotalDto.CartItems.Where(x => x.isUpdated == true).FirstOrDefault();


            if (basketTotalDto.isCouponUpdate)
            {
                basketItem.DiscountRate = basketTotalDto.DiscountRate;
                basketItem.DiscountCode = basketTotalDto.DiscountCode;

                context.Carts.Update(basketItem);
            }
            else
            {
                if (updatedBasketItem != null)
                {
                    var selectProduct = basketItem.CartItems.Where(x => x.ProductId == updatedBasketItem.ProductId).FirstOrDefault();
                    selectProduct.CartId = updatedBasketItem.CartId;
                    selectProduct.Quantity = updatedBasketItem.Quantity;
                    selectProduct.ProductId = updatedBasketItem.ProductId;

                    context.CartItem.Update(selectProduct);
                }

                else
                {
                    var lastBasketItem = basketTotalDto.CartItems.LastOrDefault();
                    var cartItem = new CartItem
                    {
                        CartId = lastBasketItem.CartId,
                        ProductId = lastBasketItem.ProductId,
                        Quantity = lastBasketItem.Quantity,
                    };
                    await context.CartItem.AddAsync(cartItem);
                }
            }


            await context.SaveChangesAsync();
        }
    }
}
