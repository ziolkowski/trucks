namespace Trucks.Dto
{
    public record CreateTruckDto
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
    }
}
