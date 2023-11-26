using FluentValidation;
using QualiWatchApi.Domain.Model.Produtos;


namespace QualiWatchApi.Application.Produtos.Commands.Update;

public class UpdateProdutoCommandValidation : AbstractValidator<UpdateProdutoCommand>
{
	public UpdateProdutoCommandValidation()
	{
        RuleFor(p => p.Id).NotEmpty().WithMessage(ProdutoConfig.MenssagemNulo);
        RuleFor(x => x.Nome)
                .MaximumLength(ProdutoConfig.MaximoTamanho).WithMessage(ProdutoConfig.MenssagemTamanhoMaximo);
        RuleFor(x => x.Lote)
            .MaximumLength(ProdutoConfig.MaximoTamanho).WithMessage(ProdutoConfig.MenssagemTamanhoMaximo);
    }
}
