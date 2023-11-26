namespace QualiWatchApi.Contracts.Produtos
{
    public record UpdateProdutoRequest(string? Nome, string? Lote, DateTime? Validade);
}
