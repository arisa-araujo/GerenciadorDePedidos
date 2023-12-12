using AutoMapper;
using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.DTOS;

namespace GerenciadorDePedidos.Repository
{
    public class CustomerRepository : GenericOwnedRepository<Customer, CustomerDTO>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }

    }
}