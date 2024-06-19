using MediatR;
using Microsoft.AspNetCore.Mvc;
using QualiWatchApi.Application.Produtos.Commands.Create;
using QualiWatchApi.Application.Produtos.Commands.Delete;
using QualiWatchApi.Application.Produtos.Commands.Update;
using QualiWatchApi.Application.Produtos.Queries.Read;
using QualiWatchApi.Application.Produtos.Queries.ReadById;
using QualiWatchApi.Application.Produtos.Queries.ReadPertoDeVencer;
using QualiWatchApi.Contracts.Produtos;

namespace QualiWatchApi.Api.Controllers;

[Route("api/[Controller]")]
public class ProdutosController : ApiController
{
    private readonly ISender _mediator;
    public ProdutosController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetProduto()
    {
        var command = new ReadProdutoQuery();
        var produto = await _mediator.Send(command);
        return produto.Match(
            Ok,
            Problem);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProdutoById(string id)
    {
        var command = new ReadProdutoByIdQuery(id);
        var produto = await _mediator.Send(command);
        return produto.Match(
            Ok,
            Problem);
    }
    [HttpPost("validade")]
    public async Task<IActionResult> GetProdutoPertoDeExpirar([FromBody] GetProdutosPertoDeExpirar produtosPertoDeExpirar)
    {
        var command = new ReadProdutoPertoDeVencerQuery(produtosPertoDeExpirar.UltimaAtulizacao);
        var produto = await _mediator.Send(command);
        return Ok(produto);
    }
    [HttpPost]
    public async Task<IActionResult> PostProduto([FromBody] CriarProdutoRequest request)
    {
        var command = new CreateProdutoCommand(request.Nome, request.Lote, request.Validade);
        var produto = await _mediator.Send(command);
        return produto.Match(
            Ok,
            Problem);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduto(string id, [FromBody] UpdateProdutoRequest request)
    {
        var command = new UpdateProdutoCommand(request.Nome, request.Lote, request.Validade, id);
        var erro = await _mediator.Send(command);
        return erro.Match(
            _ => NoContent(),
            Problem);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(string id)
    {
        var command = new RemoveProdutoCommand(id);
        var erro = await _mediator.Send(command);
        return erro.Match(
            _ => NoContent(),
            Problem);
    }
}
