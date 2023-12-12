namespace GerenciadorDePedidos.DTOS
{
    public class OrderDTO : IDTO, IOwnedDTO
    {
        public string Id { get; set; } = String.Empty;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int OrderNumber { get; set; }
        public string CustomerId { get; set; } = String.Empty;
        public string CustomerName { get; set; } = String.Empty;

        public string OrderTermsId { get; set; } = String.Empty;
        public string OrderTermsName { get; set; } = String.Empty;
        public double Paid { get; set; } = 0;
        public double OrderTotal { get; set; } = 0;
        public string UserId { get; set; } = null!;
    }
}