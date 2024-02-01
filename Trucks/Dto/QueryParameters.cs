using Trucks.Enums;

namespace Trucks.Dto
{
    public class QueryParameters
    {
        public List<TruckStatus> Statuses { get; set; } = new List<TruckStatus>();
        public bool? IsDeleted { get; set; }
        public SortItem? SortBy { get; set; }
    }
}
