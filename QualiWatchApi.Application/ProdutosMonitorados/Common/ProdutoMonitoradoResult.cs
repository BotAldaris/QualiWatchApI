namespace QualiWatchApi.Application.ProdutosModificados.Common
{
    public record ProdutoMonitoradoResult(string Id, string Nome, int PermaneciaEmEstoque, int DiasAteRemocaoAposAlerta, DateTime Data);
}
