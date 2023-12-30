using ErrorOr;
using MediatR;
using QualiWatchApi.Application.Common.Interfaces.Persistence;
using QualiWatchApi.Application.Produtos.Common;
using QualiWatchApi.Domain.Model.Produtos;

namespace QualiWatchApi.Application.Produtos.Commands.Create;

public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommand, ErrorOr<ProdutoResult>>
{
    private readonly IProdutoRepository _produtoRepository;

    public CreateProdutoCommandHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ErrorOr<ProdutoResult>> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = Produto.Criar(request.Nome, request.Lote, request.Validade);
        await _produtoRepository.AdicionarProduto(produto);
        var result = new ProdutoResult(produto.Id.ToString(), produto.Nome, produto.Lote, produto.Validade);
        return result;
    }
}
