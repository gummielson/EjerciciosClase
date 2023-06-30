using System;

namespace ColorsManagment.Domain.CustomExceptions
{
    public class CannotInsertDataException : Exception
    {
        public CannotInsertDataException()
        {

        }

        public CannotInsertDataException(string message) : base(message) { }
    }
}
