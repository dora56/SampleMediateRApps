namespace SampleMediatRApps.Applications.Carts.Queries;

public record GetCartContentsQuery(Guid CartId) : IRequest<CartResponse>;
