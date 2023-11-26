using FluentValidation;

namespace QualiWatchApi.Application.Imagem.Queries.Texto;

public   class TextoQueryValidator : AbstractValidator<TextoQuery>
{
    public TextoQueryValidator()
    {
        RuleFor(i => i.Base64).NotEmpty().WithMessage("Precisa ter a base64 para poder realizar a conversão");
    }
}
