namespace SampleMediatRApps.Applications.Products.Commands;

public record CreateProductCommand(string Name, decimal Price) : IRequest<Guid>;