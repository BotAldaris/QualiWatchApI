using ErrorOr;
using MediatR;
using QualiWatchApi.Application.ProdutosModificados.Common;

namespace QualiWatchApi.Application.ProdutosMonitorados.Queries.Read;

public record ReadProdutoMonitoradoQuery(DateTime? Inicio, DateTime? Fim) : IRequest<ErrorOr<List<ProdutoMonitoradoResult>>>;
