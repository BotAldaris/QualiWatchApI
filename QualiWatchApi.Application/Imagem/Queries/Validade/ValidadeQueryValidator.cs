using FluentValidation;

namespace QualiWatchApi.Application.Imagem.Queries.Validade;

public   class ValidadeQueryValidator : AbstractValidator<ValidadeQuery>
{
    public ValidadeQueryValidator()
    {
        RuleFor(i => i.Base64).NotEmpty().WithMessage("Precisa ter a base64 para poder realizar a conversão");
    }
}
