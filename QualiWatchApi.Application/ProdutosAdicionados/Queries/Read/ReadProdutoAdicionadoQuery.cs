using ErrorOr;
using MediatR;
using QualiWatchApi.Application.ProdutosAdicionados.Common;

namespace QualiWatchApi.Application.ProdutosAdicionados.Queries.Read;

public record ReadProdutoAdicionadoQuery(bool Adicionado, DateTime? Inicio, DateTime? fim) : IRequest<ErrorOr<List<ProdutoAdicionadoResult>>>;
