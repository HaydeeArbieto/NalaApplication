using NalaApplication.Helpers;
using NalaApplication.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NalaApplication.Repositories;

namespace NalaApplication.Services
{
    public class CartsService
    {
        private readonly ProductsRepository _rep;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public CartsService(IHttpContextAccessor httpContextAccessor, ProductsRepository rep)
        {
            _httpContextAccessor = httpContextAccessor;
            _rep = rep;
        }

        public async Task<Cart> AddItemToCart(int id)
        {
            var cart = new Cart();

            if (SessionHelper.GetObjectFromJson<Cart>(_session, "cart") == null)
            {
                cart.CartItems.Add(new CartItem { Product = await GetProductFromRepository(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(_session, "cart", cart);
            }
            else
            {
                cart = SessionHelper.GetObjectFromJson<Cart>(_session, "cart");

                int index = isExist(cart, id);
                if (index != -1)
                {
                    cart.CartItems[index].Quantity++;
                }
                else
                {
                    cart.CartItems.Add(new CartItem { Product = await GetProductFromRepository(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(_session, "cart", cart);
            }

            return cart;
        }

        public Cart RemoveItemToCart(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<Cart>(_session, "cart");
            int index = isExist(cart, id);
            cart.CartItems.RemoveAt(index);
            SessionHelper.SetObjectAsJson(_session, "cart", cart);
            return cart;
        }

        private async Task<Product> GetProductFromRepository(int id)
        {
            return await _rep.GetProductByIdAsync(id);
        }

        private int isExist(Cart cart, int id)
        {
            for (int i = 0; i < cart.CartItems.Count; i++)
            {
                if (cart.CartItems[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}

