namespace CH13_EventSourcing.BankApp
{
    internal sealed class InvalidDateException : Exception
    {
        public InvalidDateException() : base()
        {
        }

        public InvalidDateException(string? message) : base(message)
        {
        }

        public InvalidDateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
