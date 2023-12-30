using ErrorOr;
using MediatR;
using QualiWatchApi.Application.Common.Interfaces.Persistence;
using QualiWatchApi.Application.Produtos.Common;


namespace QualiWatchApi.Application.Produtos.Queries.Read;

public class ReadProdutoQueryHandler : IRequestHandler<ReadProdutoQuery, ErrorOr<List<ProdutoResult>>>
{
    private readonly IProdutoRepository _produtoRepository;

    public ReadProdutoQueryHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ErrorOr<List<ProdutoResult>>> Handle(ReadProdutoQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var produtos = _produtoRepository.PegarTodosOsProdutos();
        List<ProdutoResult> result = produtos.ConvertAll(p => new ProdutoResult(p.Id.ToString(), p.Nome, p.Lote, p.Validade));
        if(result is null)
        {
           return new List<ProdutoResult>();
        }
        return result;
    }
}