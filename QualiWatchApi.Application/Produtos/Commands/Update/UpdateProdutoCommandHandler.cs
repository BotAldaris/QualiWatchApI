using ErrorOr;
using MediatR;
using QualiWatchApi.Application.Common.Interfaces.Persistence;
using QualiWatchApi.Domain.Common.Erros;


namespace QualiWatchApi.Application.Produtos.Commands.Update
{
    public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand, ErrorOr<bool>>
    {
        private readonly IProdutoRepository _produtoRepository;

        public UpdateProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<ErrorOr<bool>> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            var erro = await _produtoRepository.AtualizarProduto(Guid.Parse(request.Id),request.Nome, request.Lote, request.Validade);
            if (erro)
            {
                return Erros.Produtos.ProdutoInvalido;
            }
            return false;
        }
    }
}
