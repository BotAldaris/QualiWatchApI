using ErrorOr;
using MediatR;
using QualiWatchApi.Application.Common.Interfaces.Persistence;


namespace QualiWatchApi.Application.ProdutosMonitorados.Commands.Delete;

internal class DeleteProdutoMonitoradoCommandHandle : IRequestHandler<DeleteProdutoMonitoradoCommand, ErrorOr<bool>>
{
    private readonly IProdutoMonitoradoRepository _repository;

    public DeleteProdutoMonitoradoCommandHandle(IProdutoMonitoradoRepository repository)
    {
        _repository = repository;
    }
    public async Task<ErrorOr<bool>> Handle(DeleteProdutoMonitoradoCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var result = _repository.DeletarProdutoMonitorado(Guid.Parse(request.Id));
        if (!result)
        {
            return Domain.Common.Erros.Erros.Produtos.ProdutoInvalido;
        }
        return result;
    }
}
