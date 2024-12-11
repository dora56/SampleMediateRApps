namespace SampleMediatRApps.Domain.Carts;

public class CartItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid ProductId { get; set; }
    public int Quantity { get; private set; }
    
    public decimal Price { get; set; } =　100;

    // Parameterless constructor for EF Core
    private CartItem() { }

    public CartItem(Guid productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }

    public CartItem UpdateQuantity(int quantity)
    {
        return new CartItem(ProductId, quantity);
    }
    
    public decimal　TotalPrice()
    {
        return Price * Quantity;
    }
}