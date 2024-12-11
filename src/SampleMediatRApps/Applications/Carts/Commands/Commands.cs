namespace SampleMediatRApps.Applications.Carts.Commands;

public record AddCartItemCommand(Guid CartId, Guid ProductId, int Quantity) : IRequest<Guid>;
public record UpdateCartItemCommand(Guid CartId, Guid ProductId, int Quantity) : IRequest;
public record RemoveCartItemCommand(Guid CartId, Guid ProductId) : IRequest;