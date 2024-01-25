using QualiWatchApi.Application.Common.Interfaces.Persistence;
using QualiWatchApi.Application.Common.Interfaces.Services;
using QualiWatchApi.Domain.Model.Produtos;

namespace QualiWatchApi.Infrastructure.Services.Validade;

public class ValidadeServices : IValidadeServices
{
    private readonly IValidadeRepository _validadeRepository;

    public ValidadeServices( IValidadeRepository validadeRepository)
    {
        _validadeRepository = validadeRepository;
    }

    public void AtualizarPertoDeVencer(DateTime? validade, Produto produto)
    {
        if (validade is not null)
        {
            if (validade > DateTime.Now.AddMonths(1) && produto.FoiAlertado)
            {
                _validadeRepository.DeletarValidade(produto);
            }else if (DateTime.Now.AddMonths(1) > validade && produto.FoiAlertado == false)
            {
                _validadeRepository.AdicionarValidade(produto);
            }
        }
    }
}