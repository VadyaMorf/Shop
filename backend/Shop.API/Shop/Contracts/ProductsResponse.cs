namespace Shop.Contracts
{
    public record ProductsResponse(Guid id, string Title, string Description, decimal Price, byte[] Image, string Size, decimal Count);
}
