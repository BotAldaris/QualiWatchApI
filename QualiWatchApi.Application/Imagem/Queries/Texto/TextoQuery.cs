using MediatR;
using QualiWatchApi.Domain.Common;

namespace QualiWatchApi.Application.Imagem.Queries.Texto;

public record TextoQuery(string Base64) : IRequest<List<ImageResponse>>;

