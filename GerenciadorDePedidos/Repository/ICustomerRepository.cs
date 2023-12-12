using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.DTOS;

namespace GerenciadorDePedidos.Repository
{
    public interface ICustomerRepository : IGenericOwnedRepository<Customer, CustomerDTO>
    {
        
    }

}