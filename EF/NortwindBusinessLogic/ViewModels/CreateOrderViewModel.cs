using System;
using System.Collections.Generic;
using System.Text;

namespace NortwindBusinessLogic.ViewModels
{
    public class CreateOrderViewModel
    {
        public string CustomerId { get; set; }
        public List<ProductQuantityViewModel> Products { get; set; }
    }
}
