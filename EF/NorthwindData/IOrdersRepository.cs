using NorthwindData.Dto;
using NorthwindData.Models;
using System;
using System.Collections.Generic;

namespace NorthwindData
{
    public interface IOrdersRepository : IRepository
    {
        void AddOrder(Order order);
        void ChangeOrderStatus(Order customer);
        IEnumerable<Order> GetNewestOrders(int limit);
        IEnumerable<Order> GetOrdersFrom(DateTime from);
        OrderStatistic GetStatisticsForCurrentMonth();
        OrderStatistic GetStatisticsForMonth(DateTime date);
    }
}