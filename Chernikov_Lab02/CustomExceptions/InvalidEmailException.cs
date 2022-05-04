using System;

namespace Chernikov_Lab02.CustomExceptions
{
    class InvalidEmailException : Exception
    {
        public InvalidEmailException(string message)
            : base(message)
        {

        }
    }
}
