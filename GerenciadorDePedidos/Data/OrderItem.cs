using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GerenciadorDePedidos.Data
{
    public class OrderItem : IEntity, IOwnedEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string OrderId { get; set; } = String.Empty;
        public Order? Order { get; set; } = null!;

        public string Description { get; set; } = String.Empty;
        
        public double UnitPrice { get; set; }
        
        public double Quantity { get; set; }

        public double TotalPrice { get; private set; }

        public string UserId { get; set; } = null!;
        public IdentityUser? User { get; set; } = null!;

    }
}