using System.Security.Claims;
using AutoMapper;
using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.DTOS;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDePedidos.Repository
{
    public class CustomerRepository : GenericOwnedRepository<Customer, CustomerDTO>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }

    }
}