using MediatR;
using Trucks.Dto;

namespace Trucks.DataAccess.Queries.GetTruckById
{
    public class GetTruckByIdQuery : IRequest<TruckDto>
    {
        public Guid Id { get; set; }

        public GetTruckByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
