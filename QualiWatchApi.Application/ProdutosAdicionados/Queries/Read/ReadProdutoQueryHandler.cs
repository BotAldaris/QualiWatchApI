using ErrorOr;
using MediatR;
using QualiWatchApi.Application.Common.Interfaces.Persistence;
using QualiWatchApi.Application.ProdutosAdicionados.Common;

namespace QualiWatchApi.Application.ProdutosAdicionados.Queries.Read;

public class ReadProdutoQueryHandler : IRequestHandler<ReadProdutoAdicionadoQuery, ErrorOr<List<ProdutoAdicionadoResult>>>
{
    private readonly IProdutoAdicionadoRepository _produtoAdicionadoRepository;
    private readonly IProdutoMonitoradoRepository _monitoradoRepository;

    public ReadProdutoQueryHandler(IProdutoAdicionadoRepository repository, IProdutoMonitoradoRepository monitoradoRepository)
    {
        _produtoAdicionadoRepository = repository;
        _monitoradoRepository=monitoradoRepository;
    }
    public async Task<ErrorOr<List<ProdutoAdicionadoResult>>> Handle(ReadProdutoAdicionadoQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (request.Adicionado)
        {
            var produtos = _produtoAdicionadoRepository.GetAllProdutosAdicionados(request.Inicio, request.fim);
            var result = produtos.ConvertAll(x => new ProdutoAdicionadoResult(x.Id.ToString(), x.Nome, x.Data));
            if (result is null)
            {
                return new List<ProdutoAdicionadoResult>();
            }
            return result;
        }
        else
        {
            var produtos = _monitoradoRepository.GetAllProdutosMonitorados(request.Inicio, request.fim);
            var result = produtos.ConvertAll(x => new ProdutoAdicionadoResult(x.Id.ToString(), x.Nome, x.Data));
            if (result is null)
            {
                return new List<ProdutoAdicionadoResult>();
            }
            return result;
        }
    }
}
