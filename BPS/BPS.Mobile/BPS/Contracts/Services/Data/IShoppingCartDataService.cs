using System.Threading.Tasks;
using BPS.Core.Models;

namespace BPS.Core.Contracts.Services.Data
{
    public interface IShoppingCartDataService
    {
        Task<ShoppingCart> GetShoppingCart(string userId);
        Task<ShoppingCartItem> AddShoppingCartItem(ShoppingCartItem shoppingCartItem, string userId);
    }
}
