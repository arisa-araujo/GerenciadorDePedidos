using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GerenciadorDePedidos.Data
{
    public class Order :IEntity, IOwnedEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserId { get; set; } = null!;
        public IdentityUser? User { get; set; } = null!;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderNumber { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public string CustomerId { get; set; } = String.Empty;
        public Customer? Customer { get; set; } = null!;

        public string OrderTermsId { get; set; } = String.Empty;
        public OrderTerms? OrderTerms { get; set; } = null!;

        public double Paid { get; set; } = 0;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}