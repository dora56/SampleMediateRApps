namespace SampleMediatRApps.Infrastructure.Data;

public class CartDbContext(DbContextOptions<CartDbContext> options) : DbContext(options)
{
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>()
            .HasMany(c => c.Items)
            .WithOne()
            .HasForeignKey("CartId");

        base.OnModelCreating(modelBuilder);
    }
}