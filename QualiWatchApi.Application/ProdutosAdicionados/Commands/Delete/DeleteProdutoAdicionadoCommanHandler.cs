using ErrorOr;
using MediatR;
using QualiWatchApi.Application.Common.Interfaces.Persistence;
using QualiWatchApi.Domain.Common.Erros;

namespace QualiWatchApi.Application.ProdutosAdicionados.Commands.Delete
{
    internal class DeleteProdutoAdicionadoCommanHandler : IRequestHandler<DeleteProdutoAdicionadoCommand, ErrorOr<bool>>
    {
        private readonly IProdutoAdicionadoRepository _produtoAdicionadoRepository;
        public DeleteProdutoAdicionadoCommanHandler(IProdutoAdicionadoRepository produtoAdicionadoRepository)
        {
            _produtoAdicionadoRepository = produtoAdicionadoRepository;
        }
        public async Task<ErrorOr<bool>> Handle(DeleteProdutoAdicionadoCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var result = _produtoAdicionadoRepository.DeletarProdutoAdicionado(Guid.Parse(request.Id));
            if (!result)
            {
                return Erros.Produtos.ProdutoInvalido;
            }
            return result;
        }
    }
}
