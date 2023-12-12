namespace GerenciadorDePedidos.DTOS
{
    public class OrderItemDTO : IDTO, IOwnedDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string OrderId { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public string UserId { get; set; } = null!;
    }
}