using System.Security.Claims;
using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.DTOS;

namespace GerenciadorDePedidos.Repository
{
    public interface IOrderItemRepository : IGenericOwnedRepository<OrderItem, OrderItemDTO>
    {
        public Task<List<OrderItemDTO>> GetAllByOrderId(ClaimsPrincipal User, string orderId);
    }
}