using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.Schema
{
    public class ProductRequest
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string ProductDescription { get; set; }
        public int Stok { get; set; }
        public int DealerId { get; set; }

    }
    public class ProductResponse
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string ProductDescription { get; set; }
        public int Stok { get; set; }
        public int DealerId { get; set; }
        public string  DealerName { get; set; }
        public List<OrderItemsResponse> OrderItems { get; set; }
    }
}
