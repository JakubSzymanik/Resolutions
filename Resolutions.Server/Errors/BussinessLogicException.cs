namespace Resolutions.Server.Errors
{
    public class BussinessLogicException : Exception
    {
        public BussinessLogicException()
        {
        }

        public BussinessLogicException(string? message) : base(message)
        {
        }

        public BussinessLogicException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
