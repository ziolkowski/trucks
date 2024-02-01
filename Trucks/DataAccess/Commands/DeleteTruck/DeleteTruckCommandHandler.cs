using MediatR;
using Trucks.DataAccess.Repositories;

namespace Trucks.DataAccess.Commands.DeleteTruck
{
    public class DeleteTruckCommandHandler : IRequestHandler<DeleteTruckCommand>
    {
        private readonly ITruckRepository _truckRepository;

        public DeleteTruckCommandHandler(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task Handle(DeleteTruckCommand request, CancellationToken ct)
            => await _truckRepository.Delete(request.TruckId, ct);
    }
}
