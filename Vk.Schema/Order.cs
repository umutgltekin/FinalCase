namespace Vk.Schema
{
    public class OrderRequest
    {
        public string OrderName { get; set; }
        public int UserId { get; set; }
        public int DealerId { get; set; }
        public int  OrderNumber { get; set; }

    }
    public class OrderResponse
    {
        public string OrderName { get; set; }
        public int UserId { get; set; }
        public int DealerId { get; set; }
        public int OrderNumber { get; set; }
        public string DealerName { get; set; }
        public string UserName { get; set; }
        public virtual List<OrderItemsResponse> OrderItems { get; set; }
    }
}