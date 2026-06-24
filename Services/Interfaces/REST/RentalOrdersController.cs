using System.Net.Mime;
using Pc27414u202319440.API.Services.Application.Services;
using Pc27414u202319440.API.Services.Interfaces.REST.Resources;
using Pc27414u202319440.API.Services.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Pc27414u202319440.API.Services.Interfaces.REST;

/// <summary>
/// REST controller for rental order operations.
/// </summary>
/// <remarks>Dhilsen Armil Mallqui Vilca</remarks>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Rental Orders")]
public class RentalOrdersController(
    IRentalOrderCommandService rentalOrderCommandService,
    ILogger<RentalOrdersController> logger) : ControllerBase
{
    /// <summary>
    /// Creates a rental order.
    /// </summary>
    /// <param name="resource">Creation request payload.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created rental order resource.</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a rental order",
        Description = "Creates a rental order with the provided customer, vehicle, plate, requested date, address and amount.",
        OperationId = "CreateRentalOrder")]
    [SwaggerResponse(201, "The rental order was created", typeof(RentalOrderResource))]
    [SwaggerResponse(400, "The request payload is invalid", typeof(string))]
    [SwaggerResponse(409, "A business rule conflict occurred", typeof(string))]
    [SwaggerResponse(500, "Unexpected server error", typeof(ProblemDetails))]
    public async Task<ActionResult> CreateRentalOrder(
        [FromBody] CreateRentalOrderResource resource,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = CreateRentalOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await rentalOrderCommandService.Handle(command, cancellationToken);
            return ActionResultFromCreateRentalOrderResultAssembler.ToActionResultFromCreateRentalOrderResult(
                result,
                this);
        }
        catch (ArgumentException exception)
        {
            logger.LogWarning(exception,
                "Validation failed while creating rental order for customer {Customer} and vehicle {VehiclesId}",
                resource.Customer,
                resource.VehiclesId);

            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            logger.LogError(exception,
                "Unexpected error while creating rental order for customer {Customer} and vehicle {VehiclesId}",
                resource.Customer,
                resource.VehiclesId);

            return Problem(
                title: "Unexpected server error",
                detail: "An unexpected error occurred while creating the rental order.",
                statusCode: 500);
        }
    }
}
