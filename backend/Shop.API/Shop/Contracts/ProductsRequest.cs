namespace Shop.Contracts
{
    public record ProductsRequest(string Title, string Description, decimal Price, byte[] Image, string Size, decimal Count);
}
