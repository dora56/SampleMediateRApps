namespace SampleMediatRApps.Applications.Carts.Handlers;

public class GetCartContentsQueryHandler(ICartRepository repository): IRequestHandler<GetCartContentsQuery, CartResponse>
{
    public async Task<CartResponse> Handle(GetCartContentsQuery request, CancellationToken cancellationToken)
    {
        var cart = await repository.GetCartByIdAsync(request.CartId);
        if (cart == null) return new CartResponse();

        return new CartResponse
        {
            Id = cart.Id,
            Items = cart.Items.Select(item => new CartItemResponse
            (item.ProductId, item.Quantity))
                .ToList()
        };
    }
}