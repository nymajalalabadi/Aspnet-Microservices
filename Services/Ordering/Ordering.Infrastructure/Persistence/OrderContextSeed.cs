using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!await orderContext.Orders.AnyAsync())
            {
                await orderContext.Orders.AddRangeAsync(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("data seed section configured");
            }
        }

        public static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>()
            {
                new Order
                {
                    FirstName = "nyma",
                    LastName = "jalali",
                    UserName = "nyma",
                    EmailAddress = "email@email.com",
                    City = "mahabad",
                    Country = "iran",
                    TotalPrice = 1000000
                },
                new Order
                {
                    FirstName = "mohammad",
                    LastName = "ordookhani",
                    UserName = "mohammad",
                    EmailAddress = "test@test.com",
                    City = "tehran",
                    Country = "iran",
                    TotalPrice = 10000
                }
            };
        }
    }
}
