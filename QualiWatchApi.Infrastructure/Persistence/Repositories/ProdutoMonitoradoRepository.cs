using QualiWatchApi.Application.Common.Interfaces.Persistence;
using QualiWatchApi.Domain.Model.Estatistica;

namespace QualiWatchApi.Infrastructure.Persistence.Repositories
{
    internal class ProdutoMonitoradoRepository : IProdutoMonitoradoRepository
    {
        private readonly QualiWatchApiDbContext _dbContext;
        public ProdutoMonitoradoRepository(QualiWatchApiDbContext dbContext)
        {
            _dbContext =dbContext;
        }
        public void AdicionarProdutoMonitorado(ProdutoMonitorado produto)
        {
            _dbContext.Add(produto);
            _dbContext.SaveChanges();
        }

        public bool DeletarProdutoMonitorado(Guid id)
        {
            var produto = ReadProdutoById(id);
            if (produto == null)
            {
                return false;
            }
            _dbContext.ProdutoMonitorados.Remove(produto);
            _dbContext.SaveChanges();
            return true;
        }

        public List<ProdutoMonitorado> GetAllProdutosMonitorados(DateTime? inicio, DateTime? fim)
        {
            if (inicio == null && fim == null)
            {
                return [.. _dbContext.ProdutoMonitorados];
            }
            else if (inicio == null)
            {
                return [.. _dbContext.ProdutoMonitorados.Where(it => fim  >= it.Data)];
            }
            else if (fim == null)
            {
                return [.. _dbContext.ProdutoMonitorados.Where(it => it.Data >= inicio)];
            }
            return [.. _dbContext.ProdutoMonitorados.Where(it => inicio <= it.Data && it.Data <= fim)];
        }

        public ProdutoMonitorado? ReadProdutoById(Guid id)
        {
            return _dbContext.ProdutoMonitorados.FirstOrDefault(a => a.Id == id);
        }
    }
}
