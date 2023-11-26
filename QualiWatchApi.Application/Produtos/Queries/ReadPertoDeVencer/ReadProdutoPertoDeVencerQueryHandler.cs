using MediatR;
using QualiWatchApi.Application.Common.Interfaces.Persistence;
using QualiWatchApi.Application.Produtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiWatchApi.Application.Produtos.Queries.ReadPertoDeVencer;

public class ReadProdutoPertoDeVencerQueryHandler : IRequestHandler<ReadProdutoPertoDeVencerQuery, List<ProdutoResult>>
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IValidadeRepository _validadeRepository;

    public ReadProdutoPertoDeVencerQueryHandler(IProdutoRepository produtoRepository, IValidadeRepository validadeRepository)
    {
        _produtoRepository = produtoRepository;
        _validadeRepository = validadeRepository;
    }
    public async Task<List<ProdutoResult>> Handle(ReadProdutoPertoDeVencerQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var produtosIds = _validadeRepository.GetProdutosPertoDeVencer(request.UltimaAtualizacao);
        // var produtos = _produtoRepository.GetProdutosPertoDeVencer(produtosIds);
        List<ProdutoResult> result = produtosIds.ConvertAll(p => new ProdutoResult(p.Id.ToString(), p.Nome, p.Lote, p.Validade));
        return result;
    }
}
