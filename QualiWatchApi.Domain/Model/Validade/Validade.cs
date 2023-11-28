using QualiWatchApi.Domain.Model.Produtos;

namespace QualiWatchApi.Domain.Model.Validade;

public class Validade
{
    public Guid Id { get; private set; }
    public Guid ProdutoId { get; set; }
    public virtual Produto Produto { get; set; }    
    public DateTime DiaAdicionado { get; set; }
    private Validade(Guid id, Guid produtoId, DateTime diaAdicionado)
    {
        Id = id;
        ProdutoId = produtoId;
        DiaAdicionado = diaAdicionado;
    }
    public static Validade Criar(Guid produtoId)
    {
        return new Validade(Guid.NewGuid(), produtoId, DateTime.UtcNow);
    }
}
