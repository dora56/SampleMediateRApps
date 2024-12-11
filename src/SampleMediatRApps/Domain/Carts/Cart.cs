namespace SampleMediatRApps.Domain.Carts;

public class Cart
{
    public Guid Id { get; init; }
    public IList<CartItem> Items { get; init; }

    // Parameterless constructor
    public Cart()
    {
        Id = Guid.NewGuid();
        Items = new List<CartItem>();
    }

    // Constructor with parameters
    public Cart(Guid id, IList<CartItem> items)
    {
        Id = id;
        Items = items;
    }


    public Cart AddItem(CartItem item)
    {
        Items.Add(item);
        return new Cart(Id, Items);
    }

    public Cart RemoveItem(Guid productId)
    {
        var item = FindCartItem(productId);
        if (item == null)
        {
            return this;
        }
        Items.Remove(item);
        return new Cart(Id, Items);
    }

    public Cart UpdateItem(CartItem item)
    {
        var index = Items.ToList().FindIndex(x => x.ProductId == item.ProductId);
        if (index < 0)
        {
            throw new InvalidOperationException("Item not found");
        }

        var newItems = Items.ToList();
        newItems[index] = item;
        return new Cart(Id, newItems);
    }

    public CartItem? FindCartItem(Guid productId)
    {
        return Items.FirstOrDefault(item => item.ProductId == productId);
    }

    public decimal TotalPrice()
    {
        return Items.Sum(x => x.TotalPrice());
    }
}