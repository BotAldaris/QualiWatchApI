using MediatR;
using QualiWatchApi.Application.Common.Interfaces.Image;
using QualiWatchApi.Domain.Common;

namespace QualiWatchApi.Application.Imagem.Queries.Texto;

public class TextoQueryHandler : IRequestHandler<TextoQuery, List<ImageResponse>>
{
    private readonly IImagemParaTexto _imagemParaTexto;

    public TextoQueryHandler(IImagemParaTexto imagemParaTexto)
    {
        _imagemParaTexto = imagemParaTexto; 
    }

    public async Task<List<ImageResponse>> Handle(TextoQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var validades = _imagemParaTexto.GetValidade(request.Base64);
        return validades;
    }
}
