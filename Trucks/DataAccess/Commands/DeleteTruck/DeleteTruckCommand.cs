using MediatR;

namespace Trucks.DataAccess.Commands.DeleteTruck
{
    public class DeleteTruckCommand : IRequest
    {
        public Guid TruckId { get; set; }

        public DeleteTruckCommand(Guid truckId)
        {
            TruckId = truckId;
        }
    }
}
