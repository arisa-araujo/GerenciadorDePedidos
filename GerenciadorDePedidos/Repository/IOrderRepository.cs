using System.Security.Claims;
using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.DTOS;

namespace GerenciadorDePedidos.Repository
{
    public interface IOrderRepository : IGenericOwnedRepository<Order, OrderDTO>
    {
        public Task DeleteWithOrderItems(ClaimsPrincipal User, string orderId);
        public Task<List<OrderDTO>> GetAllMineFlat(ClaimsPrincipal User);
    }
}