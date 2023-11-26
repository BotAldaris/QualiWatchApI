using ErrorOr;
using MediatR;
using QualiWatchApi.Application.Produtos.Common;

namespace QualiWatchApi.Application.Produtos.Commands.Create
{
    public record CreateProdutoCommand(string Nome, string Lote, DateTime Validade) : IRequest<ErrorOr<ProdutoResult>>;
}
