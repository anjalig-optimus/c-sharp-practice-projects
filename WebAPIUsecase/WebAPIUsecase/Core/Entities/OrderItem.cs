namespace WebAPIUsecase.Core.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } // Many-to-One with Order
        public int ProductId { get; set; }
        public Product Product { get; set; } // Many-to-One with Product
        public int Quantity { get; set; }
        public decimal TotalPrice => Product.Price * Quantity;
    }
}
