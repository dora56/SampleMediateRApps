using SampleMediatRApps.Domain.Carts;

namespace SampleMediatRApps.Applications.Carts.Handlers;

public class UpdateCartItemCommandHandler: IRequestHandler<UpdateCartItemCommand>
{
    private readonly ICartRepository _repository;

    public UpdateCartItemCommandHandler(ICartRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await _repository.GetCartByIdAsync(request.CartId);
        if (cart != null)
        {
            var cartItem = new CartItem(request.ProductId, request.Quantity);
            var updatedCart = cart.UpdateItem(cartItem);
            
            await _repository.AddCartAsync(updatedCart);
        }
    }
}