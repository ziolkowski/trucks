using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;
using Trucks.Dto;
using Trucks.Utilities.Exceptions;
using Trucks.DataAccess.Queries.GetAllTrucks;
using Trucks.DataAccess.Queries.GetTruckById;
using Trucks.DataAccess.Commands.CreateTruck;
using Trucks.DataAccess.Commands.UpdateTruck;
using Trucks.DataAccess.Commands.DeleteTruck;
using Trucks.DataAccess.Commands.SetTruckStatus;

namespace Trucks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TruckController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TruckController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation("Gets all trucks")]
        public async Task<IActionResult> GetAllTrucks(CancellationToken ct, [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] QueryParameters? parameters = null)
            => await Execute(() => _mediator.Send(new GetAllTrucksQuery(parameters), ct));

        [HttpGet("{truckId}")]
        [SwaggerOperation("Gets truck by id")]
        public async Task<IActionResult> GetTruckById(Guid truckId, CancellationToken ct)
            => await Execute(() => _mediator.Send(new GetTruckByIdQuery(truckId), ct));        

        [HttpPost("create")]
        [SwaggerOperation("Creates a truck")]
        public async Task<IActionResult> CreateTruck([FromBody] CreateTruckDto dto, CancellationToken ct)
            => await Execute(() => _mediator.Send(new CreateTruckCommand(dto), ct));

        [HttpPatch]
        [SwaggerOperation("Updates a truck")]
        public async Task<IActionResult> UpdateTruck([FromBody] UpdateTruckDto dto, CancellationToken ct)
            => await Execute(() => _mediator.Send(new UpdateTruckCommand(dto), ct));

        [HttpDelete("{truckId}")]
        [SwaggerOperation("Deletes a truck")]
        public async Task<IActionResult> DeleteTruck(Guid truckId, CancellationToken ct)
            => await Execute(() => _mediator.Send(new DeleteTruckCommand(truckId), ct));

        [HttpPatch("status")]
        [SwaggerOperation("Updates truck status")]
        public async Task<IActionResult> SetTruckStatus([FromBody] UpdateTruckStatusDto dto, CancellationToken ct)
            => await Execute(() => _mediator.Send(new UpdateTruckStatusCommand(dto), ct));

        private async Task<IActionResult> Execute(Func<Task> func)
        {
            try
            {
                await func();
                return Ok();
            }
            catch (BusinessNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BusinessConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private async Task<IActionResult> Execute<T>(Func<Task<T>> func)
        {
            try
            {
                return Ok(await func());
            }
            catch (BusinessNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BusinessConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
