using MediatR;
using Trucks.Dto;

namespace Trucks.DataAccess.Queries.GetAllTrucks
{
    public class GetAllTrucksQuery : IRequest<IEnumerable<TruckDto>>
    {
        public QueryParameters? QueryParameters { get; set; }

        public GetAllTrucksQuery(QueryParameters? queryParameters)
        {
            QueryParameters = queryParameters;
        }
    }
}
