using MediatR;
using Trucks.Dto;

namespace Trucks.DataAccess.Commands.SetTruckStatus
{
    public class UpdateTruckStatusCommand : IRequest
    {
        public UpdateTruckStatusDto Model { get; set; }

        public UpdateTruckStatusCommand(UpdateTruckStatusDto model)
        {
            Model = model;
        }
    }
}
