using Trucks.Enums;
using Trucks.Model;

namespace Trucks.Utilities
{
    public static class TruckExtensions
    {
        public static IQueryable<Truck> FilterByIsDeleted(this IQueryable<Truck> query, bool isDeleted)
            => query.Where(x => x.IsDeleted == isDeleted);

        public static IQueryable<Truck> FilterByStatuses(this IQueryable<Truck> query, IEnumerable<TruckStatus> statuses)
        {
            var isOutOfService = statuses.Contains(TruckStatus.OutOfService);
            var isLoading = statuses.Contains(TruckStatus.Loading);
            var isToJob = statuses.Contains(TruckStatus.ToJob);
            var isAtJob = statuses.Contains(TruckStatus.AtJob);
            var isReturning = statuses.Contains(TruckStatus.Returning);

            return query.Where(x =>
                (isOutOfService && x.Status == TruckStatus.OutOfService) ||
                (isLoading && x.Status == TruckStatus.Loading) ||
                (isToJob && x.Status == TruckStatus.ToJob) ||
                (isAtJob && x.Status == TruckStatus.AtJob) ||
                (isReturning && x.Status == TruckStatus.Returning));
        }

        public static IQueryable<Truck> SortBy(this IQueryable<Truck> query, SortItem? sortItem)
            => sortItem switch
            {
                SortItem.Name => query.OrderBy(x => x.Name),
                SortItem.NameDescending => query.OrderByDescending(x => x.Name),
                SortItem.Status => query.OrderBy(x => x.Status),
                SortItem.StatusDescending => query.OrderByDescending(x => x.Status),
                SortItem.CreatedDate => query.OrderBy(x => x.CreationDateTime),
                SortItem.CreatedDateDescending => query.OrderByDescending(x => x.CreationDateTime),
                _ => query.OrderBy(x => x.Name)
            };
    }
}
