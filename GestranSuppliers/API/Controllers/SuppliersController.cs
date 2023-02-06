using GestranSuppliers.Application.Commands;
using GestranSuppliers.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestranSuppliers.API.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class SuppliersController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public SuppliersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Supplier>> CreateSupplier(
        [FromBody] CreateSupplierCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}