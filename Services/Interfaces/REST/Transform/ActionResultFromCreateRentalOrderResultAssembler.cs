using Pc27414u202319440.API.Services.Application.Errors;
using Pc27414u202319440.API.Services.Domain.Model.Aggregates;
using Pc27414u202319440.API.Shared.Application.Patterns;
using Microsoft.AspNetCore.Mvc;

namespace Pc27414u202319440.API.Services.Interfaces.REST.Transform;

/// <summary>
/// Assembles HTTP action results from rental order command outcomes.
/// </summary>
public static class ActionResultFromCreateRentalOrderResultAssembler
{
    /// <summary>
    /// Maps a command result to an HTTP action result.
    /// </summary>
    /// <param name="result">Application result.</param>
    /// <param name="controller">Controller instance.</param>
    /// <returns>HTTP action result.</returns>
    public static ActionResult ToActionResultFromCreateRentalOrderResult(
        Result<RentalOrder, CreateRentalOrderError> result,
        ControllerBase controller) =>
        result switch
        {
            Result<RentalOrder, CreateRentalOrderError>.Success success =>
                controller.Created(
                    $"/api/v1/rental-orders/{success.Value.Id}",
                    RentalOrderResourceFromEntityAssembler.ToResourceFromEntity(success.Value)),

            Result<RentalOrder, CreateRentalOrderError>.Failure failure =>
                failure.Error switch
                {
                    CreateRentalOrderError.DuplicateCustomerAndVehicle =>
                        controller.Conflict("A rental order with the same customer and vehicle already exists."),

                    CreateRentalOrderError.PlateBelongsToDifferentVehicle =>
                        controller.Conflict("The provided plate is already associated with a different vehicle."),

                    CreateRentalOrderError.UnexpectedError =>
                        controller.Problem(
                            title: "Unexpected server error",
                            detail: "An unexpected error occurred while creating the rental order.",
                            statusCode: 500),

                    _ => controller.Problem(
                        title: "Unexpected server error",
                        detail: "An unexpected error occurred while processing the request.",
                        statusCode: 500)
                },

            _ => controller.Problem(
                title: "Unexpected server error",
                detail: "An unexpected error occurred while processing the request.",
                statusCode: 500)
        };
}
