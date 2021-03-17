using System;

namespace NorthwindData.Dto
{
    public class OrderStatistic
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public decimal NetSum { get; set; }
    }
}
