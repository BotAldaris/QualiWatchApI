namespace QualiWatchApi.Contracts.Produtos;

public record CriarProdutoRequest(string Nome, string Lote, DateTime Validade);
