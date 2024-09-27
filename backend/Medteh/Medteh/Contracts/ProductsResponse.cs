namespace Medteh.API.Contracts
{
    public record ProductsResponse(Guid id, string Title, string Description, decimal Price);
}
