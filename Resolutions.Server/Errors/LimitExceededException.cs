
namespace Resolutions.Server.Errors
{
    public class LimitExceededException : BussinessLogicException
    {
        public LimitExceededException()
        {
        }
        
        public LimitExceededException(string? message) : base(message)
        {
        }
        
        public LimitExceededException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
