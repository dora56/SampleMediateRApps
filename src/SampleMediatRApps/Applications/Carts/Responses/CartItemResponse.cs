namespace SampleMediatRApps.Applications.Carts.Responses;

public record CartItemResponse(Guid ProductId, int Quantity);