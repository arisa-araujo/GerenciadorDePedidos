using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GerenciadorDePedidos.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderTerms> OrderTerms { get; set; }

    // disables cascading delete
    protected void RemoveFixups (ModelBuilder modelBuilder, Type type)
    {
        foreach(var relationship in modelBuilder.Model.FindEntityType(type)!.GetForeignKeys())
        {
            relationship.DeleteBehavior = DeleteBehavior.ClientNoAction;
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //customizations
        RemoveFixups(builder, typeof(Order));
        RemoveFixups(builder, typeof(Customer));
        RemoveFixups(builder, typeof(OrderTerms));
        RemoveFixups(builder, typeof(OrderItem));

        builder.Entity<Order>().Property(u => u.OrderNumber).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        // calculates the total price 
        builder.Entity<OrderItem>()
            .Property(u => u.TotalPrice)
            .HasComputedColumnSql("[UnitPrice] * [Quantity]");


        base.OnModelCreating(builder);
    }

}
