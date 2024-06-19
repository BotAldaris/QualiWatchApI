using System.ComponentModel.DataAnnotations;

namespace QualiWatchApi.Domain.Model.Estatistica;

public class ProdutoAdicionado
{
    [Key]
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public DateTime Data { get; private set; }

    private ProdutoAdicionado(Guid id, string nome, DateTime data)
    {
        Id = id;
        Nome = nome;
        Data = data;
    }
    public static ProdutoAdicionado Criar(string nome)
    {
        return new ProdutoAdicionado(Guid.NewGuid(), nome, DateTime.UtcNow);
    }
}
