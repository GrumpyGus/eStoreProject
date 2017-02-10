using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.ViewModels
{
    public class OrderViewModel
    {
        public string UserId { get; set; }
        public int OrderId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int QtySold { get; set; }
        public int QtyOrdered { get; set; }
        public int QtyBackOrdered { get; set; }
        public string DateCreated { get; set; }
        public decimal SoldPrice { get; set; }
    }
}
