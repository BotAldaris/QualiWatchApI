﻿using MediatR;
using QualiWatchApi.Application.Common.Interfaces.Image;
using QualiWatchApi.Domain.Common;

namespace QualiWatchApi.Application.Imagem.Queries.Validade;

public class TextoQueryHandler : IRequestHandler<ValidadeQuery, List<ImageResponse>>
{
    private readonly IImagemParaTexto _imagemParaTexto;

    public TextoQueryHandler(IImagemParaTexto imagemParaTexto)
    {
        _imagemParaTexto = imagemParaTexto; 
    }

    public async Task<List<ImageResponse>> Handle(ValidadeQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var validades = _imagemParaTexto.PegarValidade(request.Base64);
        return validades;
    }
}
