using NorthwindData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAPI.ViewModels
{
    public class CreateOrderViewModel
    {
        public string CustomerId { get; set; }
        public List<ProductQuantityViewModel> Products { get; set; }
    }
}
