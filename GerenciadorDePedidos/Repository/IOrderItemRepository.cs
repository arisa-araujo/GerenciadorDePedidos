using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.DTOS;

namespace GerenciadorDePedidos.Repository
{
    public interface IOrderItemRepository : IGenericOwnedRepository<OrderItem, OrderItemDTO>
    {
        
    }
}