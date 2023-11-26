using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiWatchApi.Application.Produtos.Commands.Delete;

public record RemoveProdutoCommand(string Id) : IRequest<ErrorOr<bool>>;
