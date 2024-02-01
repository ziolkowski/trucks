using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Trucks.Database;
using Trucks.Dto;
using Trucks.Model;
using Trucks.Utilities.Exceptions;
using Trucks.Utilities;

namespace Trucks.DataAccess.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        private readonly TruckContext _context;
        private readonly IMapper _mapper;

        public TruckRepository(TruckContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TruckDto>> GetAll(QueryParameters? queryParameters, CancellationToken ct)
        {
            var query = _context.Trucks.AsNoTracking();
            if (queryParameters is null)
            {
                return _mapper.Map<List<TruckDto>>(query);
            }
            if (queryParameters.IsDeleted.HasValue)
            {
                query = query.FilterByIsDeleted((bool)queryParameters.IsDeleted);
            }
            if (queryParameters.Statuses.Any())
            {
                query = query.FilterByStatuses(queryParameters.Statuses);
            }

            query = query.SortBy(queryParameters.SortBy);
            var trucks = await query.ToListAsync(ct);

            return _mapper.Map<List<TruckDto>>(trucks);
        }

        public async Task<TruckDto> GetOne(Guid id, CancellationToken ct)
        {
            var truck = await _context.Trucks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);
            ThrowIfNull(truck);
            if (truck.IsDeleted)
            {
                throw new BusinessNotFoundException("Truck with given id has been deleted.");
            }

            return _mapper.Map<TruckDto>(truck);
        }

        public async Task<Guid> Create(CreateTruckDto dto, CancellationToken ct)
        {
            var truck = _mapper.Map<Truck>(dto);
            truck.CreationDateTime = DateTime.UtcNow;
            _context.Trucks.Add(truck);
            await _context.SaveChangesAsync(ct);

            return truck.Id;
        }

        public async Task Update(UpdateTruckDto dto, CancellationToken ct)
        {
            var targetTruck = await _context.Trucks.FirstOrDefaultAsync(x => x.Id == dto.Id, ct);
            ThrowIfNull(targetTruck);
            targetTruck.Name = dto.Name ?? targetTruck.Name;
            targetTruck.Code = dto.Code ?? targetTruck.Code;
            targetTruck.Description = dto.Description ?? dto.Description;
            _context.Trucks.Update(targetTruck);
            await _context.SaveChangesAsync(ct);
        }

        public async Task Delete(Guid id, CancellationToken ct)
        {
            var targetTruck = await _context.Trucks.FirstOrDefaultAsync(x => x.Id == id, ct);
            ThrowIfNull(targetTruck);
            targetTruck.IsDeleted = true;
            _context.Trucks.Update(targetTruck);
            await _context.SaveChangesAsync(ct);
        }

        public async Task UpdateStatus(UpdateTruckStatusDto dto, CancellationToken ct)
        {
            var targetTruck = await _context.Trucks.FirstOrDefaultAsync(x => x.Id == dto.Id, ct);
            ThrowIfNull(targetTruck);
            targetTruck.Status = dto.Status;
            _context.Trucks.Update(targetTruck);
            await _context.SaveChangesAsync(ct);
        }

        private void ThrowIfNull(Truck? truck)
        {
            if (truck is null)
            {
                throw new BusinessNotFoundException("Truck not found.");
            }
        }
    }
}
