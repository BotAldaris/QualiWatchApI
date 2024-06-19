using MediatR;
using Microsoft.AspNetCore.Mvc;
using QualiWatchApi.Application.ProdutosAdicionados.Commands.Delete;
using QualiWatchApi.Application.ProdutosAdicionados.Queries.Read;
using QualiWatchApi.Application.ProdutosMonitorados.Commands.Delete;
using QualiWatchApi.Application.ProdutosMonitorados.Queries.Read;

namespace QualiWatchApi.Api.Controllers;

[Route("api/[Controller]")]
public class EstatisticasController : ApiController
{
    private readonly ISender _mediator;
    public EstatisticasController(ISender mediator)
    {
        _mediator =  mediator;
    }
    [HttpGet("Produtos-Adicionados")]
    public async Task<IActionResult> GetProdutosAdicionados([FromQuery] bool adicionado, [FromQuery] DateTime? inicio = null, [FromQuery] DateTime? fim = null)
    {
        var query = new ReadProdutoAdicionadoQuery(adicionado, inicio, fim);
        var result = await _mediator.Send(query);
        return result.Match(Ok, Problem);
    }
    [HttpGet("Produtos-Monitorados")]
    public async Task<IActionResult> GetProdutosMonitorados([FromQuery] DateTime? inicio = null, [FromQuery] DateTime? fim = null)
    {
        var query = new ReadProdutoMonitoradoQuery(inicio, fim);
        var result = await _mediator.Send(query);
        return result.Match(Ok, Problem);
    }
    [HttpDelete("Produtos-Adicionados/{id}")]
    public async Task<IActionResult> DeleteProdutosAdicionados([FromBody] string id)
    {
        var command = new DeleteProdutoAdicionadoCommand(id);
        var result = await _mediator.Send(command);
        return result.Match(_ => NoContent(), Problem);
    }
    [HttpDelete("Produtos-Monitorados/{id}")]
    public async Task<IActionResult> DeleteProdutosMonitorados([FromBody] string id)
    {
        var command = new DeleteProdutoMonitoradoCommand(id);
        var result = await _mediator.Send(command);
        return result.Match(_ => NoContent(), Problem);
    }
}
