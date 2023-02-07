using GestranSuppliers.Application.Commands;
using GestranSuppliers.Application.Queries;
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

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Supplier>> GetSupplierById(Guid id)
    {
        if (string.IsNullOrEmpty(id.ToString()))
            return BadRequest("Invalid ID.");
        
        var request = new GetSupplierByIdQuery(id);
        var result = await _mediator.Send(request);

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Supplier>>> GetAllSuppliersByFilters(
        [FromBody] GetAllSuppliersQuery query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Supplier>> CreateSupplier(
        [FromBody] CreateSupplierCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Supplier>> UpdateSupplierById(
        [FromBody] UpdateSupplierCommand command,
        Guid id)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Supplier>> DeleteSupplierById(Guid id)
    {
        if (string.IsNullOrEmpty(id.ToString()))
            return BadRequest("Invalid ID.");

        var request = new DeleteSupplierByIdCommand(id);
        var result = await _mediator.Send(request);

        return Ok(result);
    }
}