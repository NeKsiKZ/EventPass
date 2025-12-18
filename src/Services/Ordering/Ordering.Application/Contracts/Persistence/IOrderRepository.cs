using Ordering.Domain.Models;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Persistence
{
    public interface IOrderRepository
    {
        Task<Order> AddAsync(Order order);
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}