using AutoMapper;
using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.DTOS;

namespace GerenciadorDePedidos.Repository
{
    public class OrderTermsRepository : GenericOwnedRepository<OrderTerms, OrderTermsDTO>, IOrderTermsRepository
    {
        public OrderTermsRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}