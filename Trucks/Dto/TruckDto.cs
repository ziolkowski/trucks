using Trucks.Enums;

namespace Trucks.Dto
{
    public record TruckDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? Description { get; set; }
        public TruckStatus Status { get; set; }
    }
}
