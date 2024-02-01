using MediatR;
using Trucks.Dto;

namespace Trucks.DataAccess.Commands.UpdateTruck
{
    public class UpdateTruckCommand : IRequest
    {
        public UpdateTruckDto Model { get; set; }

        public UpdateTruckCommand(UpdateTruckDto model)
        {
            Model = model;
        }
    }
}