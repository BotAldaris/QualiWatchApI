using QualiWatchApi.Application.Common.Interfaces.Persistence;

using QualiWatchApi.Domain.Model.Produtos;

namespace QualiWatchApi.Infrastructure.Persistence.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly QualiWatchApiDbContext _dbContext;

    public ProdutoRepository(QualiWatchApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(Produto produto)
    {
        await _dbContext.Produtos.AddAsync(produto);
        await _dbContext.SaveChangesAsync();
    }

    public bool Delete(Guid id)
    {
        var produtoParaApagar = ReadProdutoById(id);
        if (produtoParaApagar is null)
        {
            return true;
        }
        _dbContext.Produtos.Remove(produtoParaApagar!);
        _dbContext.SaveChanges();
        return false;
    }

    public List<Produto> Read()
    {
        return _dbContext.Produtos.OrderBy(p => p.Validade).ToList();
    }

    public Produto? ReadProdutoById(Guid id)
    {
        return _dbContext.Produtos.FirstOrDefault(p => p.Id == id);
    }

    public async Task<bool> Update(Guid id, string? nome = null, string? lote = null , DateTime? validade = null)
    {
        Produto? produtoOriginal = ReadProdutoById(id);
        if(produtoOriginal is null)
        {
            return true;
        }
        else {
            _dbContext.Update(produtoOriginal);
             produtoOriginal.Update(nome,lote,validade);
            await _dbContext.SaveChangesAsync();
            return false;
        }
    }
}
