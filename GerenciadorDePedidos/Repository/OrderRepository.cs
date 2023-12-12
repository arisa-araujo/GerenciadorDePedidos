using AutoMapper;
using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.DTOS;

namespace GerenciadorDePedidos.Repository
{
    public class OrderRepository : GenericOwnedRepository<Order, OrderDTO>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context, IMapper mapper) :base(context, mapper) { }
    }
}