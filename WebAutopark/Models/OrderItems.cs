namespace WebAutopark.DAO;

public class OrderItems
{
    public int OrderItemId { get; set; } = 0;

    public int OrderId { get; set; } = 0;

    public int ComponentId { get; set; } = 0;

    public int Quantity { get; set; } = 0;
}
