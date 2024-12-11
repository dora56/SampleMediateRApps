namespace SampleMediatRApps.Applications.Carts.Handlers;

public class RemoveCartItemCommandHandler(ICartRepository repository) : IRequestHandler<RemoveCartItemCommand>
{
    private readonly ICartRepository _repository = repository;

    public async Task Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await _repository.GetCartByIdAsync(request.CartId);
        if (cart != null)
        {
            var newCart = cart.RemoveItem(request.ProductId);
            await _repository.AddCartAsync(newCart);
        }
    }
}