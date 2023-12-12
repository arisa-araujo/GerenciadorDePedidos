using AutoMapper;
using GerenciadorDePedidos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GerenciadorDePedidos.Repository
{
    public class RepositoryCollection : IRepositoryCollection
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public IOrderRepository Order { get; private set; }

        public ICustomerRepository Customer  { get; private set; }

        public IOrderTermsRepository OrderTerms  { get; private set; }

        public IOrderItemRepository OrderItem  { get; private set; }
        public RepositoryCollection(IDbContextFactory<ApplicationDbContext> dbFactory, IMapper mapper)
        {
            this.context = dbFactory.CreateDbContext();
            this.mapper = mapper;
            this.Order = new OrderRepository(context, mapper);
            this.Customer = new CustomerRepository(context, mapper);
            this.OrderTerms = new OrderTermsRepository(context, mapper);
            this.OrderItem = new OrderItemRepository(context, mapper);
        }

        

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> Save()
        {
            try
            {
                return await context.SaveChangesAsync();
                
            }
            catch(DbUpdateException ex)
            {
                foreach(EntityEntry item in ex.Entries)
                {
                    if (item.State == EntityState.Modified)
                    {
                        item.CurrentValues.SetValues(item.OriginalValues);
                        item.State = EntityState.Unchanged;
                        throw new RepositoryUpdateDbException();
                    }
                    else if (item.State == EntityState.Deleted)
                    {
                        item.State = EntityState.Unchanged;
                        throw new RepositoryDeleteException();
                    }
                    else if (item.State==EntityState.Added)
                    {
                        throw new RepositoryAddException();
                    }
                }
            }
            return 0;
        }
    }
}