using ErrorOr;
using MediatR;
using QualiWatchApi.Application.Produtos.Common;

namespace QualiWatchApi.Application.Produtos.Queries.Read
{
    public record ReadProdutoQuery() : IRequest<ErrorOr<List<ProdutoResult>>>;
}
