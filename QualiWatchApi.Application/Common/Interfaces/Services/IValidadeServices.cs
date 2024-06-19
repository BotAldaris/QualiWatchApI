using QualiWatchApi.Domain.Model.Produtos;
using QualiWatchApi.Domain.Model.Validade;

namespace QualiWatchApi.Application.Common.Interfaces.Services;

public interface IValidadeServices
{
    void AtualizarPertoDeVencer(DateTime? validade, Produto produto);

    Validade? GetValidadeByProduct(Guid id);
}