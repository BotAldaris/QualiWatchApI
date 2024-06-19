
using ErrorOr;
using MediatR;
using QualiWatchApi.Application.Common.Interfaces.Persistence;
using QualiWatchApi.Application.ProdutosModificados.Common;

namespace QualiWatchApi.Application.ProdutosMonitorados.Queries.Read
{
    internal class ReadProdutoMonitoradoQueryHandler : IRequestHandler<ReadProdutoMonitoradoQuery, ErrorOr<List<ProdutoMonitoradoResult>>>
    {
        private readonly IProdutoMonitoradoRepository _repository;

        public ReadProdutoMonitoradoQueryHandler(IProdutoMonitoradoRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<List<ProdutoMonitoradoResult>>> Handle(ReadProdutoMonitoradoQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var produtos = _repository.GetAllProdutosMonitorados(request.Inicio, request.Fim);
            var result = produtos.ConvertAll(it => new ProdutoMonitoradoResult(it.Id.ToString(), it.Nome, it.PermaneciaEmEstoque, it.DiasAteRemocaoAposAlerta, it.Data));
            if (result is null)
            {
                return new List<ProdutoMonitoradoResult>();
            }
            return result;
        }
    }
}
