using Trucks.Dto;

namespace Trucks.DataAccess.Repositories
{
    public interface ITruckRepository
    {
        Task<IEnumerable<TruckDto>> GetAll(QueryParameters? queryParameters, CancellationToken ct);
        Task<TruckDto> GetOne(Guid id, CancellationToken ct);
        Task<Guid> Create(CreateTruckDto dto, CancellationToken ct);
        Task Update(UpdateTruckDto dto, CancellationToken ct);
        Task Delete(Guid id, CancellationToken ct);
        Task UpdateStatus(UpdateTruckStatusDto dto, CancellationToken ct);
    }
}
