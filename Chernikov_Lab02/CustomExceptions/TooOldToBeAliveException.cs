using System;

namespace Chernikov_Lab02.CustomExceptions
{
    class TooOldToBeAliveException : Exception
    {
        public TooOldToBeAliveException(string message)
            : base(message)
        {

        }
    }
}
