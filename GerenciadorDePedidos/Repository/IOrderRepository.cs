using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.DTOS;

namespace GerenciadorDePedidos.Repository
{
    public interface IOrderRepository : IGenericOwnedRepository<Order, OrderDTO>
    {
        
    }
}