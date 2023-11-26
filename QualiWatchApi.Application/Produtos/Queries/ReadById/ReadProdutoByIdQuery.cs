using ErrorOr;
using MediatR;
using QualiWatchApi.Application.Produtos.Common;

namespace QualiWatchApi.Application.Produtos.Queries.ReadById;

public record ReadProdutoByIdQuery(string Id) : IRequest<ErrorOr<ProdutoResult>>;
