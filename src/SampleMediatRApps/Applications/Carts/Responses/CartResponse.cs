namespace SampleMediatRApps.Applications.Carts.Responses;

public record CartResponse
{
    public Guid Id { get; set; }
    public List<CartItemResponse> Items { get; set; } = new();
    public decimal TotalAmount { get; set; }
}