using System.ComponentModel.DataAnnotations;

namespace QualiWatchApi.Domain.Model.Produtos;

public class Produto
{
    [Key]
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Lote { get; private set; }
    public DateTime Validade { get; private set; }
    
    public bool FoiAlertado { get; private set; } 

    private Produto(string nome, string lote, DateTime validade, Guid id)
    {
        Id = id;
        Nome = nome;
        Lote = lote;
        Validade = validade;
        FoiAlertado = false;
    }

    public static Produto Criar(string nome, string lote, DateTime val)
    {
        return new Produto(nome, lote, val, Guid.NewGuid());
    }

    public void Update(string? nome, string? lote, DateTime? validade)
    {
        if (nome is not null)
        {
            Nome = nome;
        }
        if (lote is not null)
        {
            Lote = lote;

        }
        if (validade is not null)
        {
            Validade = (DateTime)validade;
        }
    }

    public void SetFoiAlertado(bool foiAlertado)
    {
        FoiAlertado = foiAlertado;
    }
}
