using System.Security.Claims;
using AutoMapper;
using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.DTOS;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDePedidos.Repository
{
    public class OrderRepository : GenericOwnedRepository<Order, OrderDTO>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context, IMapper mapper) :base(context, mapper) { }

        public async Task DeleteWithOrderItems(ClaimsPrincipal User, string orderId)
        {
            string? userId = GetMyUserId(User);
            var orderItems = await context.OrderItems.Where(i => i.OrderId == orderId && i.UserId == userId).ToListAsync();
            foreach (OrderItem orderitem in orderItems)
            {
                context.OrderItems.Remove(orderitem);
            }
            Order? order = await context.Orders.Where(i => i.Id == orderId && i.UserId == userId).FirstOrDefaultAsync();
            if (order != null)
            {
                context.Orders.Remove(order);
            }
        }

        public async Task<List<OrderDTO>> GetAllMineFlat(ClaimsPrincipal User)
        {
            string? userId = GetMyUserId(User);
            var q = from i in context.Orders.Where(i => i.UserId == userId).Include(i => i.OrderItems).Include(i => i.OrderTerms).Include(i => i.Customer)
                    select new OrderDTO
                    {
                        Id = i.Id,
                        OrderDate = i.OrderDate,
                        OrderNumber = i.OrderNumber,
                        CustomerId = i.CustomerId,
                        CustomerName = i.Customer!.Name,
                        OrderTermsId = i.OrderTermsId,
                        OrderTermsName = i.OrderTerms!.Name,
                        Paid = i.Paid,
                        UserId = i.UserId,
                        OrderTotal = i.OrderItems.Sum(a => a.TotalPrice)
                    };


            List<OrderDTO>? results = await q.ToListAsync();
            return results;
        }
    }
}