namespace SampleMediatRApps.Applications.Carts.Queries;

public record GetAllCartsQuery() : IRequest<IList<CartResponse>>;