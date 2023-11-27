using QualiWatchApi.Domain.Model.Produtos;

namespace QualiWatchApi.Application.Common.Interfaces.Services;

public interface IValidadeServices
{
    void AtualizarPertoDeVencer(DateTime? validade, Produto produto);
}