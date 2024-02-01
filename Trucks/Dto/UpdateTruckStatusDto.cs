using Trucks.Enums;

namespace Trucks.Dto
{
    public class UpdateTruckStatusDto
    {
        public Guid Id { get; set; }
        public TruckStatus Status { get; set; }
    }
}
