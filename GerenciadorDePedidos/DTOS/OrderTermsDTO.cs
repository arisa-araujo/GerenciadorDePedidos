namespace GerenciadorDePedidos.DTOS
{
    public class OrderTermsDTO : IDTO, IOwnedDTO
    {
        public string Id { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string UserId { get; set; } = null!;
    }
}