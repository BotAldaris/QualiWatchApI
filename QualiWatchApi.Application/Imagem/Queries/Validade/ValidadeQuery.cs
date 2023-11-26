using MediatR;
using QualiWatchApi.Domain.Common;

namespace QualiWatchApi.Application.Imagem.Queries.Validade;

public record ValidadeQuery(string Base64) : IRequest<List<ImageResponse>>;

