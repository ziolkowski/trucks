namespace Trucks.Dto
{
    public record UpdateTruckDto : CreateTruckDto
    {
        public Guid Id { get; set; }
    }
}
