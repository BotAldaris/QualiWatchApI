using ErrorOr;
using MediatR;

namespace QualiWatchApi.Application.ProdutosAdicionados.Commands.Delete
{
    public record DeleteProdutoAdicionadoCommand(string Id) : IRequest<ErrorOr<bool>>;
}
