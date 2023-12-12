namespace GerenciadorDePedidos.Repository
{
    public interface IRepositoryCollection : IDisposable
    {
        IOrderRepository Order { get; }
        ICustomerRepository Customer{ get; }
        IOrderTermsRepository OrderTerms { get; }
        IOrderItemRepository OrderItem{ get; }

        Task<int> Save();
    }
}