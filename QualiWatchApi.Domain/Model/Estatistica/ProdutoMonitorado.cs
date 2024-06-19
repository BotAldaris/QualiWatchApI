using System.ComponentModel.DataAnnotations;

namespace QualiWatchApi.Domain.Model.Estatistica;

public class ProdutoMonitorado
{
    [Key]
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public int PermaneciaEmEstoque { get; private set; }
    public int DiasAteRemocaoAposAlerta { get; private set; }
    public DateTime Data { get; private set; }

    private ProdutoMonitorado(string nome, int permaneciaEmEstoque, int diasAteRemocaoAposAlerta, DateTime data, Guid id)
    {
        Id = id;
        Nome = nome;
        PermaneciaEmEstoque = permaneciaEmEstoque;
        DiasAteRemocaoAposAlerta = diasAteRemocaoAposAlerta;
        Data = data;
    }
    public static ProdutoMonitorado Criar(string nome, DateTime diaAdicionado, DateTime? diaAlertado)
    {
        var data = DateTime.UtcNow;
        var permaneciaEmEstoque = (diaAdicionado - data).Days;
        var diasAteRemocaoAposAlerta = -1;
        if (diaAlertado is not null)
        {
            var x = data - diaAlertado;
            if (x is not null)
            {
                diasAteRemocaoAposAlerta = x.Value.Days;
            }
        }
        return new ProdutoMonitorado(nome, permaneciaEmEstoque, diasAteRemocaoAposAlerta, data, Guid.NewGuid());
    }
}
