namespace OrderUsecase.Core.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
