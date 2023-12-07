using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GerenciadorDePedidos.Data
{
    public class OrderTerms : IEntity, IOwnedEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserId { get; set; } = null!;
        public IdentityUser? User { get; set; } = null!;

        public string Name { get; set; } = String.Empty;
    }
}