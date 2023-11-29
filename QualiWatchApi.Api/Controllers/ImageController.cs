using MediatR;
using Microsoft.AspNetCore.Mvc;
using QualiWatchApi.Application.Imagem.Queries.Texto;
using QualiWatchApi.Application.Imagem.Queries.Validade;
using QualiWatchApi.Contracts.Image;

namespace QualiWatchApi.Api.Controllers;

[Route("[Controller]")]
public class ImageController : ApiController
{
    private readonly ISender _mediator;
    public ImageController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("texto")]
    public async Task<IActionResult> GetTextFromImage([FromBody] ImageRequest imageRequest)
    {
        var query = new TextoQuery(imageRequest.Base64);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    [HttpPost("validade")]
    public async Task<IActionResult> GetValidadeFromImage([FromBody] ImageRequest imageRequest)
    {
        var query = new ValidadeQuery(imageRequest.Base64);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
