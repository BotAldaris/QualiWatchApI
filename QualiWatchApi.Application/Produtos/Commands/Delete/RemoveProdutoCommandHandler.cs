using ErrorOr;
using MediatR;
using QualiWatchApi.Application.Common.Interfaces.Persistence;
using QualiWatchApi.Domain.Common.Erros;

namespace QualiWatchApi.Application.Produtos.Commands.Delete;

public class RemoveProdutoCommandHandler : IRequestHandler<RemoveProdutoCommand, ErrorOr<bool>>
{
    private readonly IProdutoRepository _produtoRepository;

    public RemoveProdutoCommandHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    public async Task<ErrorOr<bool>> Handle(RemoveProdutoCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var erro = _produtoRepository.DeletarProduto(Guid.Parse(request.Id));
        if (erro)
        {
            return Erros.Produtos.ProdutoInvalido;
        }
        return false;
    }
}
