using ErrorOr;
using MediatR;

namespace QualiWatchApi.Application.Produtos.Commands.Update;

public record UpdateProdutoCommand(string? Nome, string? Lote, DateTime? Validade, string Id) : IRequest<ErrorOr<bool>>;
