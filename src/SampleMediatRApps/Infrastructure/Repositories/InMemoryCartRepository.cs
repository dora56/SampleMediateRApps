namespace SampleMediatRApps.Infrastructure.Repositories;

public class InMemoryCartRepository(CartDbContext context): ICartRepository
{
    public async Task<Cart?> GetCartByIdAsync(Guid cartId)
    {
        return await context.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.Id == cartId);
    }

    public async Task<Guid> AddCartAsync(Cart cart)
    {
        context.Carts.Add(cart);
        await context.SaveChangesAsync();
        return cart.Id;
    }

    public async Task<bool> RemoveCartAsync(Guid cartId)
    {
        var cart = await context.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.Id == cartId);
        if (cart == null)
        {
            return false;
        }

        context.Carts.Remove(cart);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IList<Cart>> AllCartsAsync()
    {
        return await context.Carts.Include(c => c.Items).ToListAsync();
    }
}