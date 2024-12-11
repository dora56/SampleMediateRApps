
namespace SampleMediatRApps.Domain.Carts;

public interface ICartRepository
{
    Task<Carts.Cart?> GetCartByIdAsync(Guid cartId);
    Task<Guid> AddCartAsync(Carts.Cart cart);
    Task<bool> RemoveCartAsync(Guid userId);
    
    Task<IList<Cart>> AllCartsAsync();
}