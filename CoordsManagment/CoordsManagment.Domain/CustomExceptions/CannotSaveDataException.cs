using System;

namespace CoordsManagment.Domain.CustomExceptions
{
    public class CannotSaveDataException : Exception
    {
        public CannotSaveDataException()
        {
            
        }

        public CannotSaveDataException(string message) : base(message) { }
    }
}
