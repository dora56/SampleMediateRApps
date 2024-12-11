namespace SampleMediatRApps.Applications.Carts.Handlers;

public class GetAllCartsQueryHandler(ICartRepository repository) : IRequestHandler<GetAllCartsQuery, IList<CartResponse>>
{
    public async Task<IList<CartResponse>> Handle(GetAllCartsQuery request, CancellationToken cancellationToken)
    {
        var carts = await repository.AllCartsAsync();
        return carts.Select(cart => new CartResponse
        {
            Id = cart.Id,
            Items = cart.Items.Select(item => new CartItemResponse(item.ProductId, item.Quantity)).ToList()
        }).ToList();
    }
}