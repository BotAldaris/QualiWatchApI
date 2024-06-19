using ErrorOr;
using MediatR;

namespace QualiWatchApi.Application.ProdutosMonitorados.Commands.Delete
{
    public record DeleteProdutoMonitoradoCommand(string Id) : IRequest<ErrorOr<bool>>;
}
