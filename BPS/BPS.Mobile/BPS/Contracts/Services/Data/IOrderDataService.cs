using System.Threading.Tasks;
using BPS.Core.Models;

namespace BPS.Core.Contracts.Services.Data
{
    public interface IOrderDataService
    {
        Task<Order> PlaceOrder(Order order);
    }
}
