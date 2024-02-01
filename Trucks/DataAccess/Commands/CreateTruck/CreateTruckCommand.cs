using MediatR;
using Trucks.Dto;

namespace Trucks.DataAccess.Commands.CreateTruck
{
    public class CreateTruckCommand : IRequest<Guid>
    {
        public CreateTruckDto Model { get; set; }

        public CreateTruckCommand(CreateTruckDto model)
        {
            Model = model;
        }
    }
}
