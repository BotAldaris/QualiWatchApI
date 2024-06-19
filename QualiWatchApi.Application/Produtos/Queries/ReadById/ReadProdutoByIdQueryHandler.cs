using ErrorOr;
using MediatR;
using QualiWatchApi.Application.Common.Interfaces.Persistence;
using QualiWatchApi.Application.Produtos.Common;
using QualiWatchApi.Domain.Common.Erros;

namespace QualiWatchApi.Application.Produtos.Queries.ReadById
{
    internal class ReadProdutoByIdQueryHandler : IRequestHandler<ReadProdutoByIdQuery, ErrorOr<ProdutoResult>>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ReadProdutoByIdQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<ErrorOr<ProdutoResult>> Handle(ReadProdutoByIdQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var produto = _produtoRepository.ReadProdutoById(Guid.Parse(request.Id));
            if (produto is null)
            {
                return Erros.Produtos.ProdutoInvalido;
            }
            ProdutoResult result = new(produto.Id.ToString(), produto.Nome, produto.Lote, produto.Validade);
            return result;
        }
    }
}
