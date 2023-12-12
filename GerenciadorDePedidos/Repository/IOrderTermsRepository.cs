using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.DTOS;

namespace GerenciadorDePedidos.Repository
{
    public interface IOrderTermsRepository : IGenericOwnedRepository<OrderTerms, OrderTermsDTO>
    {
        
    }
}