using SampleMediatRApps.Domain.Carts;

namespace SampleMediatRApps.Applications.Carts.Handlers;

public class AddCartItemCommandHandler(ICartRepository repository) : IRequestHandler<AddCartItemCommand, Guid>
{
    public async Task<Guid> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await repository.GetCartByIdAsync(request.CartId) ?? new Cart();
        cart.AddItem(new CartItem(request.ProductId, request.Quantity));
        await repository.AddCartAsync(cart);
        return cart.Id;
    }
}