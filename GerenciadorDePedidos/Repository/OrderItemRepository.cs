using AutoMapper;
using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.DTOS;

namespace GerenciadorDePedidos.Repository
{
    public class OrderItemRepository : GenericOwnedRepository<OrderItem, OrderItemDTO>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}