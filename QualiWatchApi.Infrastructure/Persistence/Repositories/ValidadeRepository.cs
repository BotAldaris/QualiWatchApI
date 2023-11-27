using QualiWatchApi.Application.Common.Interfaces.Persistence;
using QualiWatchApi.Domain.Model.Produtos;
using QualiWatchApi.Domain.Model.Validade;

namespace QualiWatchApi.Infrastructure.Persistence.Repositories;
public class ValidadeRepository : IValidadeRepository
{
    private readonly QualiWatchApiDbContext _dbContext;

    public ValidadeRepository(QualiWatchApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void AdicionarValidade(ref Produto produto)
    {
        produto.SetFoiAlterado(true);
       _dbContext.Validades.Add(Validade.Criar(produto.Id));
    }

    public void DeletarValidade(ref Produto produto)
    {
        var produtoId = produto.Id;
        var validade = _dbContext.Validades.FirstOrDefault(v => v.ProdutoId == produtoId);
        if (validade is not null)
        {
            produto.SetFoiAlterado(false);
            _dbContext.Validades.Remove(validade);
        }
    }

    public void AtualizarValidade()
    {
        var produtos = _dbContext.Produtos
            .Where(p => p.FoiAlertado == false && DateTime.Now.AddMonths(1) > p.Validade)
            .Select(p => p)
            .ToList();
        if (produtos.Count > 0)
        {
            produtos.ForEach(p =>
            {
                p.SetFoiAlterado(true);
                _dbContext.Validades.Add(Validade.Criar(p.Id));
            });
            _dbContext.SaveChanges();
        }
    }
    public List<Produto> GetProdutosPertoDeVencer(DateTime? ultimaAtualizacao)
    {
        if(ultimaAtualizacao is null)
        {
            var prodIds = _dbContext.Validades.Select(v => v.Produto).ToList();
            return prodIds;
        }
        else
        {
            var prodIds = _dbContext.Validades
                .Where(v => v.DiaAdicionado > ultimaAtualizacao)
                .Select(v => v.Produto)
                .ToList();
            return prodIds;
        }
         
    }
}
