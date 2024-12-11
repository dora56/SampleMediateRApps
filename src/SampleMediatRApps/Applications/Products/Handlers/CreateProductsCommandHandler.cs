using SampleMediatRApps.Applications.Products.Commands;

namespace SampleMediatRApps.Applications.Products.Handlers;

public class CreateProductsCommandHandler: IRequestHandler<CreateProductCommand, Guid>
{
    public Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}