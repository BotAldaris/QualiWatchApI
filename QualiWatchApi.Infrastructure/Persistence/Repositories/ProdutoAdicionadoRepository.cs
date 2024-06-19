using QualiWatchApi.Application.Common.Interfaces.Persistence;
using QualiWatchApi.Domain.Model.Estatistica;

namespace QualiWatchApi.Infrastructure.Persistence.Repositories;

public class ProdutoAdicionadoRepository : IProdutoAdicionadoRepository
{

    private readonly QualiWatchApiDbContext _dbContext;

    public ProdutoAdicionadoRepository(QualiWatchApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AdicionarProdutoAdicionado(ProdutoAdicionado produto)
    {
        await _dbContext.ProdutoAdicionados.AddAsync(produto);
        await _dbContext.SaveChangesAsync();
    }

    public bool DeletarProdutoAdicionado(Guid id)
    {
        var produto = ReadProdutoById(id);
        if (produto == null)
        {
            return false;
        }
        _dbContext.ProdutoAdicionados.Remove(produto);
        _dbContext.SaveChanges();
        return true;
    }

    public List<ProdutoAdicionado> GetAllProdutosAdicionados(DateTime? inicio, DateTime? fim)
    {
        if (inicio == null && fim == null)
        {
            return [.. _dbContext.ProdutoAdicionados];
        }
        else if (inicio == null)
        {
            return [.. _dbContext.ProdutoAdicionados.Where(it => fim  >= it.Data)];
        }
        else if (fim == null)
        {
            return [.. _dbContext.ProdutoAdicionados.Where(it => it.Data >= inicio)];
        }
        return [.. _dbContext.ProdutoAdicionados.Where(it => inicio <= it.Data && it.Data <= fim)];

    }
    public ProdutoAdicionado? ReadProdutoById(Guid id)
    {
        return _dbContext.ProdutoAdicionados.FirstOrDefault(a => a.Id == id);
    }
}
