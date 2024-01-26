
namespace Resolutions.Server.Errors
{
    public class CriticalBussinessLogicException : BussinessLogicException
    {
        public CriticalBussinessLogicException() {}

        public CriticalBussinessLogicException(string? message) : base(message) {}

        public CriticalBussinessLogicException(string? message, Exception? innerException) : base(message, innerException) {}
    }
}
