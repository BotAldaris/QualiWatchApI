using ErrorOr;

namespace QualiWatchApi.Domain.Common.Erros;

public static partial class Erros
{
    public static class Produtos
    {
        public static Error ProdutoInvalido => Error.NotFound(code: "Produto.ProdutoInvalido", description: "O produto com a Id fornecido não existe");
    }
}