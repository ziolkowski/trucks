using Trucks.Enums;

namespace Trucks.Model
{
    public class Truck
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? Description { get; set; }
        public TruckStatus Status { get; set; } = TruckStatus.OutOfService;
        public DateTime CreationDateTime { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
