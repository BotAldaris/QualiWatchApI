using QualiWatchApi.Application.Common.Interfaces.Persistence;
using QualiWatchApi.Application.Common.Interfaces.Services;
using QualiWatchApi.Domain.Model.Estatistica;
using QualiWatchApi.Domain.Model.Produtos;

namespace QualiWatchApi.Infrastructure.Persistence.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly QualiWatchApiDbContext _dbContext;
    private readonly IValidadeServices _validadeServices;
    private readonly IEstatisticaService _statisticaService;

    public ProdutoRepository(QualiWatchApiDbContext dbContext, IValidadeServices validadeServices, IEstatisticaService statisticaService)
    {
        _dbContext = dbContext;
        _validadeServices = validadeServices;
        _statisticaService=statisticaService;
    }
    public async Task AdicionarProduto(Produto produto)
    {
        await _dbContext.Produtos.AddAsync(produto);
        _validadeServices.AtualizarPertoDeVencer(produto.Validade, produto);
        await _statisticaService.AdicionarProdutoAdicionado(ProdutoAdicionado.Criar(produto.Nome));
        await _dbContext.SaveChangesAsync();
    }

    public bool DeletarProduto(Guid id)
    {
        var produtoParaApagar = ReadProdutoById(id);
        if (produtoParaApagar is null)
        {
            return true;
        }

        var validade = _validadeServices.GetValidadeByProduct(id);
        _statisticaService.AdicionarProdutoMonitorado(ProdutoMonitorado.Criar(produtoParaApagar.Nome, produtoParaApagar.DiaAdicionado, validade?.DiaAdicionado));
        _dbContext.Produtos.Remove(produtoParaApagar!);
        _dbContext.SaveChanges();
        return false;
    }

    public List<Produto> PegarTodosOsProdutos()
    {
        return [.. _dbContext.Produtos.OrderBy(p => p.Validade)];
    }

    public Produto? ReadProdutoById(Guid id)
    {
        return _dbContext.Produtos.FirstOrDefault(p => p.Id == id);
    }

    public async Task<bool> AtualizarProduto(Guid id, string? nome = null, string? lote = null, DateTime? validade = null)
    {
        Produto? produtoOriginal = ReadProdutoById(id);
        if (produtoOriginal is null)
        {
            return true;
        }
        else
        {
            _dbContext.Update(produtoOriginal);
            produtoOriginal.Update(nome, lote, validade);
            _validadeServices.AtualizarPertoDeVencer(validade, produtoOriginal);
            await _dbContext.SaveChangesAsync();
            return false;
        }
    }
}
