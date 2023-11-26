using FluentValidation;
using QualiWatchApi.Domain.Model.Produtos;

namespace QualiWatchApi.Application.Produtos.Commands.Create
{
    public class CreateProdutoCommandValidation : AbstractValidator<CreateProdutoCommand>
    {
        public CreateProdutoCommandValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage(ProdutoConfig.MenssagemNulo)
                .MaximumLength(ProdutoConfig.MaximoTamanho).WithMessage(ProdutoConfig.MenssagemTamanhoMaximo);
            RuleFor(x => x.Lote)
                .NotEmpty().WithMessage(ProdutoConfig.MenssagemNulo)
                .MaximumLength(ProdutoConfig.MaximoTamanho).WithMessage(ProdutoConfig.MenssagemTamanhoMaximo);
            RuleFor(x => x.Validade).NotEmpty().WithMessage(ProdutoConfig.MenssagemNulo);
        }
    }
}
