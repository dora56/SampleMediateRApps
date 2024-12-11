var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddScoped<ICartRepository, InMemoryCartRepository>();

builder.Services.AddDbContext<CartDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryCartDb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
app.MapPost("/carts/items", async (IMediator mediator, [FromBody] AddCartItemCommand command) =>
{
    var cartId = await mediator.Send(command);
    return Results.Created($"/carts/{cartId}", cartId);
});

app.MapPut("/carts/items", async (IMediator mediator, [FromBody] UpdateCartItemCommand command) =>
{
    await mediator.Send(command);
    return Results.NoContent();
});

app.MapDelete("/carts/items", async (IMediator mediator, [FromBody] RemoveCartItemCommand command) =>
{
    await mediator.Send(command);
    return Results.NoContent();
});

app.MapGet("/carts/{id}", async (IMediator mediator, Guid id) =>
{
    var cart = await mediator.Send(new GetCartContentsQuery(id));
    return Results.Ok(cart);
});

app.MapGet("/carts", async (IMediator mediator) =>
{
    var carts = await mediator.Send(new GetAllCartsQuery());
    return Results.Ok(carts);
});

await app.RunAsync();

