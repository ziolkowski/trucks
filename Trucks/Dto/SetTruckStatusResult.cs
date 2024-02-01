namespace Trucks.Dto
{
    public record SetTruckStatusResult
    {
        public bool IsValid { get; set; }
        public string? ErrorMessage { get; set; }

        public SetTruckStatusResult(bool isSuccess, string? errorMessage = null)
        {
            IsValid = isSuccess;
            ErrorMessage = errorMessage;
        }
    }
}
