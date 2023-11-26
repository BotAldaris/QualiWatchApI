using MediatR;
using QualiWatchApi.Application.Produtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiWatchApi.Application.Produtos.Queries.ReadPertoDeVencer;

public record ReadProdutoPertoDeVencerQuery(DateTime? UltimaAtualizacao) : IRequest<List<ProdutoResult>>;