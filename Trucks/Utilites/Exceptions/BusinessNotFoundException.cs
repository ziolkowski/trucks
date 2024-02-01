namespace Trucks.Utilities.Exceptions
{
    public class BusinessNotFoundException : BusinessException
    {
        public BusinessNotFoundException()
        {
        }

        public BusinessNotFoundException(string? message) : base(message)
        {
        }

        public BusinessNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
