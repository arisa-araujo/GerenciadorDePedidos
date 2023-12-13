using System.Security.Claims;
using AutoMapper;
using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.DTOS;

namespace GerenciadorDePedidos.Repository
{
    public class OrderItemRepository : GenericOwnedRepository<OrderItem, OrderItemDTO>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<List<OrderItemDTO>> GetAllByOrderId(ClaimsPrincipal User, string orderId)
        {
            return await GenericQuery(User, l => l.OrderId  == orderId, null!);
        }
    }
}