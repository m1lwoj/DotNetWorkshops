using Microsoft.EntityFrameworkCore;
using NorthwindData.Dto;
using NorthwindData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindData
{
    public class OrdersEfRepository : EfRepository
    {
        public OrdersEfRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void AddOrder(Order customer)
        {
            _dbContext.Add(customer);
        }

        public void ChangeOrderStatus(Order customer)
        {
            _dbContext.Add(customer);
        }

        public OrderStatistic GetStatisticsForCurrentMonth() => GetStatisticsForMonth(DateTime.UtcNow);

        public OrderStatistic GetStatisticsForMonth(DateTime date)
        {
            var orderDetails = _dbContext.Orders
                     .Include(a => a.OrderDetails)
                     .Where(a => a.OrderDate.HasValue && a.OrderDate.Value.Year == date.Year && a.OrderDate.Value.Month == date.Month)
                     .SelectMany(x => x.OrderDetails)
                     .AsNoTracking()
                     .ToList();

            return new OrderStatistic
            {
                Date = new DateTime(date.Year, date.Month, 1),
                Count = orderDetails.Count(),
                NetSum = orderDetails.Sum(s => s.Quantity * s.UnitPrice)
            };
        }

        public IEnumerable<Order> GetOrdersFrom(DateTime from)
        {
            return _dbContext.Orders
                  .AsNoTracking()
                  .Include(a => a.OrderDetails)
                  .Where(a => a.OrderDate.HasValue && a.OrderDate.Value > from)
                  .ToList();
        }
    }
}
