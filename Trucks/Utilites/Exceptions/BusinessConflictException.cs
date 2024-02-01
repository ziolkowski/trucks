namespace Trucks.Utilities.Exceptions
{
    public class BusinessConflictException : BusinessException
    {
        public BusinessConflictException()
        {
        }

        public BusinessConflictException(string? message) : base(message)
        {
        }

        public BusinessConflictException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
